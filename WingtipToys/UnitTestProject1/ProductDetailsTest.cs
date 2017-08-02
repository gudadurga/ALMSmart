using HallMarkTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ProductDetailsTest:Model
    {
        [TestMethod]
        public void GetProductsTestForProductName()
        {
            AllFunctionClass ProductDetailsObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductDetailsObj.GetProduct(null, "Old-time Car");

            ProductDbContext _db = new ProductDbContext();
            if (Query.Any(p => p.ProductName == "Fast Car"))
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void GetProductsTestForProductIDAndName()
        {
            AllFunctionClass ProductDetailsObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductDetailsObj.GetProduct(3, "Fast Car");
            if (Query.Any(p => p.ProductName != "Fast Car" || p.ProductID != 3))
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void GetProductsTestForProductID()
        {
            AllFunctionClass ProductDetailsObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductDetailsObj.GetProduct(7, null);
            if (Query.Any(p => p.ProductID == 1))
            {
                Assert.Fail();
            }
        }
    }
}
