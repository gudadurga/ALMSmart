using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HallMarkTest
{

    /// <summary>
    /// Model for Product and Category
    /// </summary>
    public class Model
    {
        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public int CategoryID { get; set; }
            public double UnitPrice { get; set; }
            public virtual Category Category { get; set; }

        }
        public class Category
        {

            public int CategoryID { get; set; }


            public string CategoryName { get; set; }


            public string Description { get; set; }

            public virtual ICollection<Product> Products { get; set; }
        }
    }
}
