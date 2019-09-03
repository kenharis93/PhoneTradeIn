using PhoneTradeInFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneTradeInFinal.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductView()
        {
            ProductModel productModel = new ProductModel();
            //Passes the list of products from the productmodel into the viewbag which is sent to the view
            ViewBag.products = productModel.getAll();
            return View();
        }
    }
}