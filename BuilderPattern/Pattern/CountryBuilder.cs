namespace BuilderPattern.Pattern
{
    using CodePatterns.Model;

    public class CountryBuilder
    {
        private readonly Country _country;

        public CountryBuilder()
        {
            _country = new Country
                {
                    Name = "Default",
                    Continent = new Continent{ Id = 1, Name = "Default" },
                    Currency = "Default",
                    Language = "Default"
                };
        }

        public CountryBuilder WithContinent(int id, string name)
        {
            _country.Continent = new Continent{ Id = id, Name = name };
            return this;
        }

        public CountryBuilder WithCurrency(string currency)
        {
            _country.Currency = currency;
            return this;
        }

        public CountryBuilder WithLanguage(string language)
        {
            _country.Language = language;
            return this;
        }

        public CountryBuilder WithName(string name)
        {
            _country.Name = name;
            return this;
        }

        public Country Build()
        {
            return _country;
        }
    }
}
