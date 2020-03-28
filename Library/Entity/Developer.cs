using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entity {
    public class Developer {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Establish { get; set; }
        public Developer() { }
        public Developer(string name, string notes, string city, string country, int est) {
            Name = name;
            Notes = notes;
            City = city;
            Country = country;
            Establish = est;
        }
    }
}
