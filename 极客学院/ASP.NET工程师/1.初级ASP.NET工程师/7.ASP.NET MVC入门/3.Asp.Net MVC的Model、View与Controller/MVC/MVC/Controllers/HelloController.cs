using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HelloController : Controller
    {
        //
        // GET: /Hello/

        public ActionResult Index()
        {
            //return "hello MVC";
            return View();
        }
        //public string Welcome()
        //{
        //    return "Welcome to MVC world";
        //}
        public string Welcome(string name = "zilong") //参数不安全
        {
            //Server.HtmlEncode(name);
            return "Welcome " + HttpUtility.HtmlEncode(name);
        }
    }
}
