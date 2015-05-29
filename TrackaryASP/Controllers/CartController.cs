using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TrackaryASP.Models;

namespace TrackaryASP.Controllers
{
    [Authorize]
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cart cartData;
            if (this.Session["CartData"] == null)
            {
                cartData = new Cart { };

                this.Session["CartData"] = cartData;
            }
            else
            {
                cartData = this.Session["CartData"] as Cart;
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            // Add item to cart (if available), and update the item's quantity
            if (cartData.Add(product))
            {
                product.Quantity--;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }

        // POST: Cart/Clear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clear()
        {
            // Restore item quantities
            foreach (ProductDictionary p in (this.Session["CartData"] as Cart).Products)
            {
                Product product = db.Products.Find(p.Key.ID);
                if (product != null)
                {
                    product.Quantity += p.Value;
                    db.Entry(product).State = EntityState.Modified;
                }
            }

            db.SaveChanges();

            this.Session["CartData"] = null;

            return RedirectToAction("Index", "Products");
        }
    }
}
