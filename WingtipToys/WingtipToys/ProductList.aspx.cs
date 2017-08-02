using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;
using System.Web.Routing;

namespace WingtipToys
{
  public partial class ProductList : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }

    public IQueryable<Product> GetProducts(
                        [QueryString("id")] int? categoryId,
                        [Control]int? ddlsortlist,
                        [RouteData] string categoryName)
    {
      var _db = new WingtipToys.Models.ProductContext();
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
        if(ddlsortlist.Value==1)
      query = query.OrderBy(p => p.ProductName);
        else if (ddlsortlist.Value == 2)
            query = query.OrderByDescending(p => p.ProductName);
        
      return query;
    }
  }
}