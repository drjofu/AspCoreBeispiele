using System;
using System.Collections.Generic;

namespace DbBeispiel.Models
{
    public partial class Continents
    {
        public Continents()
        {
            Countries = new HashSet<Countries>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}
