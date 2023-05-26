using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Hotcakes.Commerce;
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Extensions;
using Hotcakes.Commerce.Orders;
using Hotcakes.Commerce.Urls;

namespace Egyedi.Dnn.egyedimodul.Controllers
{
    public class KosarbaController : Controller
    {
        // GET: Kosarba
           void AddProductToCart()
            {

                var HccApp = HccAppHelper.InitHccApp();
                var p1 = HccApp.CatalogServices.Products.FindBySku("1036");
                var p2 = HccApp.CatalogServices.Products.FindBySku("505");

                int qty = 1;

                Order currentCart = HccApp.OrderServices.EnsureShoppingCart();

                LineItem li1 = HccApp.CatalogServices.ConvertProductToLineItem(p1, new OptionSelections(), qty, HccApp);
                LineItem li2 = HccApp.CatalogServices.ConvertProductToLineItem(p2, new OptionSelections(), qty, HccApp);

                HccApp.AddToOrderWithCalculateAndSave(currentCart, li1);
                HccApp.AddToOrderWithCalculateAndSave(currentCart, li2);

                Response.Redirect(HccUrlBuilder.RouteHccUrl(HccRoute.Cart));
            }
            void KosarbaBtn_Click(Object sender, EventArgs e)
            {

                Button clickedButton = (Button)sender;

                AddProductToCart();

                clickedButton.Enabled = false;
            }
        
    }
}