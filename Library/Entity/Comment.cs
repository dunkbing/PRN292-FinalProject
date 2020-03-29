using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entity {
    public class Comment {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public int Upvote { get; set; }
        public int PostID { get; set; }
        public DateTime Time { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
