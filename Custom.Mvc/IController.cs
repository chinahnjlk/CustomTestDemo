﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Custom.Mvc
{
    public interface IController
    {
        void Execute(RequestContext requestContext);

    }
}
