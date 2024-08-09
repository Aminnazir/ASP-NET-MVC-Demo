using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspMVCDemo.Models;
using AspMVCDemo.Data;
using AspMVCDemo.Models;

public class UserController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: User/Register
    public ActionResult Register()
    {
        return View();
    }

    // POST: User/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        return View(user);
    }

    // GET: User/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: User/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(User user)
    {
        var usr = db.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (usr != null)
        {
            Session["UserID"] = usr.UserId.ToString();
            Session["Username"] = usr.Username.ToString();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", "Username or Password is wrong.");
        }
        return View();
    }

    // GET: User/Logout
    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Login");
    }
}
