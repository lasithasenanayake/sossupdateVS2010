using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sossupdate
{
    
    public class ProductContract
    {
        public int product_id { get; set; }
        public string model { get; set; }
        public int qty { get; set; }
    }

    public class Responce<T> 
    {
        public T[] response { get; set; }
        public string error { get; set; }
        public bool success { get; set; }
    }

    public class ProductOptionValueContract
    {
        public int product_id { get; set; }
        public int option_value_id { get; set; }
        public int optqty { get; set; }
        public int product_option_id { get; set; }
        public int option_id { get; set; }
        public int stockqty { get; set; }
        public string model { get; set; }
        public string optionname { get; set; }
    }
}
