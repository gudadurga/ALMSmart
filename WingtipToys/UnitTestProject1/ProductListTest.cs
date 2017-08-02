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
    public class ProductListTest:Model
    {
        // Get All products without sorting, passing second paramater in method as '0'
        [TestMethod]
        void GetProductsTestForALL()
        {
            AllFunctionClass ProductListObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductListObj.GetProducts(null, 0, null);
            Assert.IsNotNull(Query);
        }

        // Get All products with sort by productname (ascending) passing second paramater in method as '1'
        [TestMethod]
        public void GetProductsTestForASC()
        {
            AllFunctionClass ProductListObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductListObj.GetProducts(null, 1, null);
            Assert.IsNotNull(Query);

        }

        // Get All products with sort by productname (Descending) passing second paramater in method as '2'
        [TestMethod]
        public void GetProductsTestForDESC()
        {
            AllFunctionClass ProductListObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductListObj.GetProducts(null, 2, null);
            Assert.IsNotNull(Query);
        }

        // Get All products with sort by productname (Descending) passing second paramater in method as '2' and Category as "Cars"
        [TestMethod]
        public void GetProductsTestForCategoryName()
        {

            AllFunctionClass ProductListObj = new AllFunctionClass();
            IQueryable<Product> Query = ProductListObj.GetProducts(null, 2, "Cars");
            if (Query.Any(p => p.Category.CategoryName == "Train"))
                Assert.Fail();

        }
    }
}
