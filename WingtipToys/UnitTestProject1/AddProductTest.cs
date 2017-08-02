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
    public class AddProductTest
    {
        [TestMethod]
        public void AddProductTestCase()
        {
            AllFunctionClass addProductObj = new AllFunctionClass();
            bool status = addProductObj.AddProduct(17, "test2", "test2", "45.5", "3", "carfast.png");
            if (!status)
                Assert.Fail();
           
        }

       
    }
}
