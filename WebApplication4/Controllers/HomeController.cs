using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Custom.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public void Index()
        {
            HttpContext.Current.Response.Write("customMvc");
        }
    }
}