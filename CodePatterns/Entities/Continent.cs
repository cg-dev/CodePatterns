﻿namespace CodePatterns.Entities
{
    using System.Collections.Generic;

    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}