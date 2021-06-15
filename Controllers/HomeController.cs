using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkedIn.Models;
using System.Data;
namespace LinkedIn.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ConnectionManager db = new ConnectionManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Login(Login r)
        {
            string query = "select * from Tbl_Registration where Email='" + r.email + "' and Password='" + r.password + "'";
            DataTable dt = db.Display_All_Records(query);
            if (dt.Rows.Count > 0)
            {
                Session["email"] = dt.Rows[0]["Email"].ToString();
                return RedirectToAction("Home", "User");
            }
            else
            {
                Response.Write("<script>alert('not matched data')</script>");
            }
            return View("Index");
        }


    }
}
