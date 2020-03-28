using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entity {
    public class Article {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public int View { get; set; }
        public string ImageUrl { get; set; }
    }
}
