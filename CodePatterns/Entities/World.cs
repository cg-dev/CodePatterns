namespace CodePatterns.Entities
{
    using System.Collections.Generic;

    using CodePatterns.Model;

    public class World
    {
        private readonly List<Country> countries;

        public List<Country> Countries
        {
            get { return this.countries; }
        }       

        public World()
        {
            var australasia = new Continent { Id = 1, Name = "Australasia" };
            var europe = new Continent { Id = 2, Name = "Europe" };
            var northAmerica = new Continent { Id = 3, Name = "North America" };
            var southAmerica = new Continent { Id = 4, Name = "South America" };
            
            this.countries = new List<Country>
                    {
                        new Country { Name = "New Zealand", Currency = "NZD", Language = "English", Continent = australasia },
                        new Country { Name = "Australia", Currency = "AUD", Language = "English", Continent = australasia },
                        new Country { Name = "England", Currency = "GBP", Language = "English", Continent = europe },
                        new Country { Name = "France", Currency = "EUR", Language = "French", Continent = europe },
                        new Country { Name = "Hungary", Currency = "HUF", Language = "Hungarian", Continent = europe },
                        new Country { Name = "Spain", Currency = "EUR", Language = "Spanish", Continent = europe },
                        new Country { Name = "Canada", Currency = "CAD", Language = "English", Continent = northAmerica },
                        new Country { Name = "Peru", Currency = "ESC", Language = "Spanish", Continent = southAmerica },
                        new Country { Name = "Mexico", Currency = "PES", Language = "Spanish", Continent = southAmerica }
                    };
        }
    }
}