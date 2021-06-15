using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkedIn.Models;
using System.Data;
using System.IO;

namespace LinkedIn.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        ConnectionManager db=new ConnectionManager();
        public ActionResult Home()
        {
            string name="",email="",address="",image="";
            if (Session["email"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                string query = "select * from Tbl_Registration where Email='"+Session["email"]+"'";
                DataTable dt = db.Display_All_Records(query);
                if (dt.Rows.Count > 0)
                {
                    name=dt.Rows[0]["Name"].ToString();
                    email=dt.Rows[0]["Email"].ToString();
                    image=dt.Rows[0]["Image"].ToString();
                }
                ViewBag.name = name;
                ViewBag.image = image;
                ViewBag.email = email;
                return View();


            }
            

        }
        
        public JsonResult naya(string msg, string name, string email, HttpPostedFileBase file,string profile)
        {
            string mm = "";
            string tu = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                file.SaveAs(tu);
                string query = "insert into Tbl_post values('" + msg + "','" + file.FileName + "','" + email + "','" + name + "','"+profile+"')";
                if(db.InsertUpdateDelete(query))
                {
                    string queryt = "select * from Tbl_post where post_image='" + file.FileName + "'";
                    DataTable dt = db.Display_All_Records(queryt);
                        if(dt.Rows.Count>0)
                        {
                           
                            mm = " <div class='row' style='background: white; border-radius: 10px; border: 1px solid #e0dfdc; min-height: 131px; margin-top: 10px; '><div class='col-lg-12'><img src='/Content/Profile/" + dt.Rows[0]["pro_image_name"] + "' alt='' style='height:40px;width:40px;border-radius:50%;margin-top:10px;' /><span style='font-size: 15px; font-family: sans-serif; font-weight: 600; text-overflow: ellipsis; color: #141414;'>   " + dt.Rows[0]["name"]+"   </span></div><div class='col-lg-12' style='height:450px;padding:0px;padding-top:10px;'><div class='col-12' style='height:12%;width:100%;'><span style='font-size:18px;font-family:sans-serif;font-weight:400;margin-top:10px;'>"+dt.Rows[0]["status"]+"</span></div><div class='col-12' style='height:78%;width:100%;padding:0px;'><img src='/Content/Images/"+dt.Rows[0]["post_image"]+"' style='height:100%;width:100%;' /></div><div class='col-12' style=height:10%;width:100%;padding:0px;'><ul><a href='#'>  <li id='ll'><img src='/Content/Images/like.png' id='ii' />Like</li></a><a href='#'>  <li id='ll'><img src='/Content/Images/nav-messaging.svg' id='ii' />Comment</li></a><a href='#'>  <li id='ll'><img src='/Content/Images/share.png' id='ii' />Share</li></a></ul></div></div></div>";
                        }
                }
                else
                {
                    mm = "not post";
                }
                return Json(mm, JsonRequestBehavior.AllowGet);
        }
    }
}
