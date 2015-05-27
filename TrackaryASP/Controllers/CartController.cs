using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TrackaryASP.Models;

namespace TrackaryASP.Controllers
{
    public class CartController : Controller
    {
        private TrackaryDbContext db = new TrackaryDbContext();

        // GET: Cart/Checkout
        public ActionResult Checkout()
        {
            return View();
        }

        // POST: Cart/AddItem/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(int? id)
        {
            var cartData = this.Session["CartData"] as Cart;
            Product product = db.Products.Find(id);
            if (product != null)
            {
                cartData.Products.Add(product);
            }

            return RedirectToAction("Index", "Products");
        }

        // POST: Cart/Clear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clear()
        {
            this.Session["CartData"] = null;

            return RedirectToAction("Index", "Products");
        }
    }
}
