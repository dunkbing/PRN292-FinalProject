using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entity {
    public class Reply {
        public int ID { get; set; }
        public int CommentID { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public DateTime Time { get; set; }
    }
}
