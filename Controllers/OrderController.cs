using System.Linq;
using System.Web.Mvc;
using AspMVCDemo.Models;
using AspMVCDemo.Data;

public class OrderController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Order/UserOrderSummary/1
    public ActionResult UserOrderSummary(int userId)
    {
        var totalOrderValue = db.Orders
                                .Where(o => o.UserId == userId)
                                .SelectMany(o => o.OrderDetails)
                                .Sum(od => od.Quantity * od.Product.Price);

        ViewBag.TotalOrderValue = totalOrderValue;
        return View();
    }
}
