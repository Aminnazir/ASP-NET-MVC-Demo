using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspMVCDemo.Models;
using AspMVCDemo.Data;
using AspMVCDemo.Helpers;

public class ProductController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Product
    public ActionResult Index()
    {
        return View(db.Products.ToList());
    }

    // GET: Product/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return View(product);
    }

    // GET: Product/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Product product, HttpPostedFileBase file)
    {
        if (ModelState.IsValid)
        {
            var filePath = FileHelper.SaveFile(file, "~/Uploads");
            if (!string.IsNullOrEmpty(filePath))
            {
                // Save file path or related information to the database if needed
            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(product);
    }

    // GET: Product/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return View(product);
    }

    // POST: Product/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    // GET: Product/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return View(product);
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Product product = db.Products.Find(id);
        db.Products.Remove(product);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    // AJAX: Get Product Details
    [HttpGet]
    public ActionResult GetProductDetails(int id)
    {
        var product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return PartialView("_ProductDetails", product);
    }
}
