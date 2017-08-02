using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HallMarkTest
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
   
        public class AllFunctionClass:Model
        {
            public bool AddProduct(int ProductID, string ProductName, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath)
            {


                var myProduct = new Product();
                myProduct.ProductID = ProductID;
                myProduct.ProductName = ProductName;
                myProduct.Description = ProductDesc;
                myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
                myProduct.ImagePath = ProductImagePath;
                myProduct.CategoryID = Convert.ToInt32(ProductCategory);

                using (ProductDbContext _db = new ProductDbContext())
                {
                    // Add product to DB.

                    _db.Database.Connection.Open();
                    _db.Products.Add(myProduct);
                    _db.SaveChanges();

                    _db.Database.Connection.Close();
                }
                // Success.
                return true;
            }

            public IQueryable<Product> GetProduct(int? productId, string productName)
            {
                var _db = new ProductDbContext();
                IQueryable<Product> query = _db.Products;
                if (productId.HasValue && productId > 0)
                {
                    query = query.Where(p => p.ProductID == productId);
                }
                else if (!String.IsNullOrEmpty(productName))
                {
                    query = query.Where(p =>
                              String.Compare(p.ProductName, productName) == 0);
                }
                else
                {
                    query = null;
                }
                return query;
            }

            public IQueryable<Product> GetProducts(int? categoryId, int? ddlsortlist, string categoryName)
            {
                var _db = new ProductDbContext();
                IQueryable<Product> query = _db.Products;

                if (categoryId.HasValue && categoryId > 0)
                {
                    query = query.Where(p => p.CategoryID == categoryId);
                }

                if (!String.IsNullOrEmpty(categoryName))
                {
                    query = query.Where(p =>
                                        String.Compare(p.Category.CategoryName,
                                        categoryName) == 0);
                }
                if (ddlsortlist.Value == 1)
                    query = query.OrderBy(p => p.ProductName);
                else if (ddlsortlist.Value == 2)
                    query = query.OrderByDescending(p => p.ProductName);

                return query;
            }
        }
    
}
