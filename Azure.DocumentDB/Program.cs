using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Azure.DocumentDB
{
    partial class Program
    {
        private const string EndpointUrl = "https://cmg422-documentdb.documents.azure.com:443/";
        private const string PrimaryKey = "OlbfOyra1PNxt6vz1x2hZGEk7VvUftiEsdLbsEx2cdZ36FWxJy1PGKQkqFQAmzTxbeJv5hd3J40euDGVExTsqQ==";
        private DocumentClient _client;

        private const string DbName = "FamilyDB";
        private const string CollectionName = "FamilyCollection";

        static void Main(string[] args)
        {
            try
            {
                var p = new Program();
                p.InitialiseDbAndCollection().Wait();
                p.WorkWithDocuments().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine($"{de.StatusCode} error occurred: {de.Message}, Message: {baseException.Message}");
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine($"Error: {e.Message}, Message: {baseException.Message}");
            }
            finally
            {
                Console.WriteLine($"End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        private async Task InitialiseDbAndCollection()
        {
            this._client = new DocumentClient(new System.Uri(EndpointUrl), PrimaryKey);

            await this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = DbName });
            await this._client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DbName), new DocumentCollection { Id = CollectionName });
        }

        private async Task WorkWithDocuments()
        {
            var andersenFamily = new Family
            {
                Id = "Andersen.1",
                Surname = "Andersen",
                Parents = new Parent[]
                {
                    new Parent{Forename = "Thomas"},
                    new Parent{Forename="Mary Kay"}
                },
                Children = new Child[]
                {
                    new Child
                    {
                        Forename="Henriette Thaulow",
                        Gender="female",
                        Grade=5,
                        Pets=new Pet[]
                        {
                            new Pet { GivenName = "Fluffy" }
                        }
                    }
                },
                Address = new Address { County = "Bedfordshire", City = "Bedford" },
                IsRegistered = true
            };
            await this.CreateFamilyDocumentIfNotExists(DbName, CollectionName, andersenFamily);

            var wakefieldFamily = new Family
            {
                Id = "Wakefield.7",
                Surname = "Wakefield",
                Parents = new Parent[]
                {
                    new Parent { Surname = "Wakefield", Forename = "Robin" },
                    new Parent { Surname = "Miller", Forename="Ben" }
                },
                Children = new Child[]
                {
                    new Child
                    {
                        Surname="Merriem",
                        Forename="Jesse",
                        Gender="female",
                        Grade=8,
                        Pets=new Pet[]
                        {
                            new Pet { GivenName = "Goofy" },
                            new Pet { GivenName = "Shadow" }
                        }
                    }
                },
                Address = new Address { County = "Buckinghamshire", City = "Milton Keynes" },
                IsRegistered = false
            };
            await this.CreateFamilyDocumentIfNotExists(DbName, CollectionName, wakefieldFamily);

            this.ExecuteSimpleQuery(DbName, CollectionName);

            andersenFamily.Children[0].Grade = 6;
            await this.ReplaceFamilyDocument(DbName, CollectionName, "Andersen.1", andersenFamily);

            this.ExecuteSimpleQuery(DbName, CollectionName);

            await this.DeleteFamilyDocument(DbName, CollectionName, "Andersen.1");

            //await this._client.DeleteDatabaseAsync(UriFactory.CreateDatabaseUri(DbName));
            //this.WriteToConsoleAndPromptToContinue($"Deleted {DbName} database");
        }

        private void WriteToConsoleAndPromptToContinue(string format)
        {
            Console.WriteLine(format);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private async Task CreateFamilyDocumentIfNotExists(string databaseName, string collectionName, Family family)
        {
            try
            {
                await this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, family.Id));
                this.WriteToConsoleAndPromptToContinue($"Found {family.Id} family");
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), family);
                    this.WriteToConsoleAndPromptToContinue($"Created family {family.Id}");
                }
                else
                {
                    throw;
                }
            }
        }

        private void ExecuteSimpleQuery(string databasName, string collectionName)
        {
            var queryOptions = new FeedOptions { MaxItemCount = -1 };

            var familyQuery = this._client
                .CreateDocumentQuery<Family>(UriFactory.CreateDocumentCollectionUri(databasName, collectionName), queryOptions)
                .Where(f => f.Surname == "Andersen");

            Console.WriteLine("Running LINQ");

            foreach (var family in familyQuery)
            {
                Console.WriteLine($"\tRead {family}");
            }

            var familyQueryInSql = this._client.CreateDocumentQuery<Family>(UriFactory.CreateDocumentCollectionUri(databasName, collectionName),
                "SELECT * FROM Family WHERE Family.Surname = 'Wakefield'", queryOptions);

            Console.WriteLine("Running direct SQL query");

            foreach (var family in familyQueryInSql)
            {
                Console.WriteLine($"\tRead {family}");
            }
        }

        private async Task ReplaceFamilyDocument(string databaseName, string collectionName, string familyName, Family updatedFamily)
        {
            await this._client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, familyName), updatedFamily);
            this.WriteToConsoleAndPromptToContinue($"Replaced family {familyName}");
        }

        private async Task DeleteFamilyDocument(string databaseName, string collectionName, string familyName)
        {
            await this._client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, familyName));
            this.WriteToConsoleAndPromptToContinue($"Deleted family {familyName}");
        }
    }
}