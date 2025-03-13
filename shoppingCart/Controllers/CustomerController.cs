using Microsoft.AspNetCore.Mvc;
using shoppingCart.Models;

namespace shoppingCart.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> category = _context.tbl_Category.ToList();
            ViewData["category"] = category;
            ViewBag.checkSession = HttpContext.Session.GetString("customer_session");  
            return View();
        }
        public IActionResult customerAccount()
        {
            string customer_session = HttpContext.Session.GetString("customer_session");
            if (customer_session != null)
            {
                List<Category> category = _context.tbl_Category.ToList();
                ViewData["category"] = category;
                var customerId = HttpContext.Session.GetString("customer_session");
                var row = _context.tbl_Customer.Where(c => c.Customer_id == int.Parse(customerId)).ToList();


                return View(row);
            }
            else
            {
                return RedirectToAction("customerLogin");
            }

           
        
        }
        public IActionResult _fetchCategoryInTabs()
        {
           
            return PartialView();
            
        }
        public IActionResult customerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult customerLogin(string Customer_email, string Customer_password)
        {
            {
                var row = _context.tbl_Customer.FirstOrDefault(a => a.Customer_email == Customer_email);
                if (row != null && row.Customer_password == Customer_password)
                {
                    HttpContext.Session.SetString("customer_session", row.Customer_id.ToString());
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.message = "Incorrect Username or Password";
                    return View();
                }
               
            }

        }
        public IActionResult customerLogout()
        {
            HttpContext.Session.Remove("customer_session");
            return RedirectToAction("Index");
        }

        public IActionResult CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerRegister(Customer customer)
        {
            _context.tbl_Customer.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("customerLogin");
        }
    }
}
