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

        // GET: Cart
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        // GET: Cart/Checkout/5
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartSessionData cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] CartSessionData cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // POST: Cart/AddItem/5?productID=2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(int? id, int productID)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.Find(productID);
                if (product != null)
                {
                    CartSessionData entry = db.Carts.Find(id);
                    if (entry != null)
                    {
                        entry.Products.Add(product);
                        //db.Entry(entry).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // POST: Cart/Clear/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clear([Bind(Include = "ID")] CartSessionData cart)
        {
            if (ModelState.IsValid)
            {
                cart.Products.Clear();
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        

        // GET: Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartSessionData cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Cart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] CartSessionData cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartSessionData cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartSessionData cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
