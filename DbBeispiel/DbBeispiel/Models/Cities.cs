using System;
using System.Collections.Generic;

namespace DbBeispiel.Models
{
    public partial class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }

        public Countries Country { get; set; }
    }
}
