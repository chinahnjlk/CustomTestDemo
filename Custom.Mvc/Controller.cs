using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Custom.Mvc
{
    public class Controller:ControllerBase,IDisposable
    {
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeing)
        {

        }

        public override void Execute(RequestContext requestContext)
        {
           var type = this.GetType();
           string actionName = requestContext.RouteData.GetRequiredString("action");
           System.Reflection.MethodInfo mi = type.GetMethod(actionName);

           //执行该Action方法
           if (mi != null) mi.Invoke(this, new object[] { });
        }
    }
}
