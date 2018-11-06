using System;
using System.Collections.Generic;

namespace DbBeispiel.Models
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
