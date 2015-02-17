namespace CodePatterns.Entities
{
    using System;

    public class Country : IComparable<Country>
    {
        public string Name { get; set; }

        public string Language { get; set; }

        public string Currency { get; set; }

        //public string Continent { get; set; }

        public int CompareTo(Country other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public int CountryId { get; set; }
        public virtual Continent Continent { get; set; }
    }
}