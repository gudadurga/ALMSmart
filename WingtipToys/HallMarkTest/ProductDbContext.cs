using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;


namespace HallMarkTest
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext()
           : base("WingtipToys")
        {

        }
        public DbSet<Model.Product> Products { get; set; }
        public DbSet<Model.Category> Category { get; set; }
    }
}
