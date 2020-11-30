﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Post
    {
         public int idPosts { get; set; }
        public int? idCategory { get; set; }
        public string briefDescription { get; set; }
        public string Description { get; set; }
        public string metaKey { get; set; }
        public string metaDescription { get; set; }
        public int? orderFooter { get; set; }
        public string image { get; set; }
        public DateTime? datePost { get; set; }
    }
}
