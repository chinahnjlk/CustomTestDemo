using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.Security;

namespace Custom.Mvc
{
    public class UrlRoutingModule : IHttpModule
    {
        #region Property
        private RouteCollection _routeCollection;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "This needs to be settable for unit tests.")]
        public RouteCollection RouteCollection
        {
            get
            {
                if (_routeCollection == null)
                {
                    _routeCollection = RouteTable.Routes;
                }
                return _routeCollection;
            }
            set
            {
                _routeCollection = value;
            }
        }
        #endregion

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += PostResolveRequestCache;
        }

        public void PostResolveRequestCache(object sender,EventArgs args)
        {
            HttpApplication context = (HttpApplication) sender;

            context.Context.RemapHandler(new MvcHandler());

        }

        void IHttpModule.Dispose()
        {
            Dispose();
        }

        void IHttpModule.Init(HttpApplication context)
        {
            Init(context);
        }

		public virtual void PostResolveRequestCache(HttpContextBase context)
        {
            RouteData routeData = RouteCollection.GetRouteData(context);

            if (routeData == null)
            {
                return;
            }
            IRouteHandler routeHandler = routeData.RouteHandler;
            if (routeHandler == null)
            {
                return;
            }
 
            RequestContext requestContext = new RequestContext(context, routeData);
            context.Request.RequestContext = requestContext;


            IHttpHandler httpHandler = routeHandler.GetHttpHandler(requestContext);
            if (httpHandler == null)
            {
                return;
            }
            context.RemapHandler(httpHandler);
            
        }
	}
}
