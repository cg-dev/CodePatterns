namespace SpecificationPattern.Entities
{
    using System.Collections.Generic;

    class World
    {

        private readonly List<Country> countries;

        public List<Country> Countries
        {
            get { return this.countries; }
        }       

        public World()
        {
            this.countries = new List<Country>
                    {
                        new Country { Name = "Australia", Currency = "AUD", Language = "English", Continent = "Australasia" },
                        new Country { Name = "Canada", Currency = "CAD", Language = "English", Continent = "North America" },
                        new Country { Name = "England", Currency = "GBP", Language = "English", Continent = "Europe" },
                        new Country { Name = "France", Currency = "EUR", Language = "French", Continent = "Europe" },
                        new Country { Name = "Mexico", Currency = "PES", Language = "Spanish", Continent = "South America" },
                        new Country { Name = "New Zealand", Currency = "NZD", Language = "English", Continent = "Australasia" },
                        new Country { Name = "Hungary", Currency = "HUF", Language = "Hungarian", Continent = "Europe" },
                        new Country { Name = "Spain", Currency = "EUR", Language = "Spanish", Continent = "Europe" }
                    };
        }
    }
}