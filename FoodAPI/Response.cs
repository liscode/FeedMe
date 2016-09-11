using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAPI
{
    public class Item
    {
        public int offset { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class List
    {
        public string lt { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int total { get; set; }
        public string sr { get; set; }
        public string sort { get; set; }
        public List<Item> item { get; set; }
    }

    public class RootObject
    {
        public List list { get; set; }
    }
}
