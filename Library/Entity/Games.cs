using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entity {
    public class Games {
        public int ID { get; set; }
        public string Title { get; set; }
        public int DevID { get; set; }
        public string Introduction { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Score { get; set; }
        public string ImageUrl { get; set; }
    }
}
