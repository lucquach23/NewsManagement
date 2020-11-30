using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Posts>();
        }

        public int idCategory { get; set; }
        public int? parentIdCategory { get; set; }
        public int rankCategory { get; set; }
        public string titleCategory { get; set; }
        public bool? showMenu { get; set; }
        public int? orderDisplay { get; set; }
        public bool? showPage { get; set; }
        public int? orderShowPage { get; set; }
        public bool? showFooter { get; set; }
        public bool? orderShowFooter { get; set; }
        public string icon { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
