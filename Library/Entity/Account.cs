﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Entity {
    public class Account {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }
}
