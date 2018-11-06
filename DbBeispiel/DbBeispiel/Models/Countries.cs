using System;
using System.Collections.Generic;

namespace DbBeispiel.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<Cities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CarCode { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public string Government { get; set; }
        public DateTime? IndependenceDate { get; set; }
        public int ContinentId { get; set; }

        public Continent Continent { get; set; }
        public ICollection<Cities> Cities { get; set; }
    }
}
