using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Category
    {
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
    }
}
