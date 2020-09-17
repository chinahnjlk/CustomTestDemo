using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace WebApplication1
{
    /// <summary>
    /// upload1 的摘要说明
    /// </summary>
    public class upload1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {



            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");

            Script.Alert("1");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Script
    {
        public static void Alert(string message)
        {
            ////window.location = '弹出提示语后，点击确认跳到你想跳的页面';
            ResponseScript("alert('" + message + "');window.close();");
        }
        public static void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n//<![CDATA[\n");
            HttpContext.Current.Response.Write(script);
            HttpContext.Current.Response.Write("\n//]]>\n</script>\n");
        }
    }
}