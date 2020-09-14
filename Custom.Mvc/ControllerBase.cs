using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Custom.Mvc
{
    public abstract class ControllerBase : IController
    {
        public abstract void Execute(RequestContext requestContext);

    }
}
