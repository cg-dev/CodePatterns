using System;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Azure.DocumentDB
{
    class Program
    {
        private const string EndpointUrl = "https://cmg-familydb.documents.azure.com:443/";
        private const string PrimaryKey = "1dW4HycgwC1D6si6CwGW7Wa5nlxrWk6OqaBAZlf85tgy8tEOEAd8uuATLMLTilNC6uZt3b2GljD3jcgzOkaY9A==";
        private DocumentClient _client;

        private const string DbName = "FamilyDB";
        private const string CollectionName = "FamilyCollection";

        static void Main(string[] args)
        {
            try
            {
                var p = new Program();
                p.GetStartedDemo().Wait();
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

        private async Task GetStartedDemo()
        {
            this._client = new DocumentClient(new System.Uri(EndpointUrl), PrimaryKey);

            await this._client.CreateDatabaseIfNotExistsAsync(new Database { Id = DbName });
            await this._client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DbName), new DocumentCollection { Id = CollectionName });

            var andersenFamily = new Family
            {
                Id = "Andersen.1",
                Surname = "Andersen",
                Parents = new Parent[]
                {
                    new Parent{Forename = "Thomas"},
                    new Parent{Forename="Mary Kay"}
                },
                Childern = new Child[]
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
                Childern = new Child[]
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
        }

        private void WriteToConsoleAndPromptToContinue(string format)
        {
            Console.WriteLine(format);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public class Family
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
            public string Surname { get; set; }
            public Parent[] Parents { get; set; }
            public Child[] Childern { get; set; }
            public Address Address { get; set; }
            public bool IsRegistered { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        public class Parent
        {
            public string Surname { get; set; }
            public string Forename { get; set; }
        }

        public class Child
        {
            public string Surname { get; set; }
            public string Forename { get; set; }
            public string Gender { get; set; }
            public int Grade { get; set; }
            public Pet[] Pets { get; set; }
        }

        public class Pet
        {
            public string GivenName { get; set; }
        }

        public class Address
        {
            public string County { get; set; }
            public string City { get; set; }
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
    }
}