using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AliMola
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SF = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //session factory
            SF = NHSFGenerator.GetNHSF();
        }
        public override void Init()
        {
            base.Init();
            this.BeginRequest += MvcApplication_BeginRequest;
            this.EndRequest += MvcApplication_EndRequest;

            this.Error += MvcApplication_Error;     

        }

        private void MvcApplication_Error(object sender, EventArgs e)
        {
            HttpApplicatio ha = (HttpApplication)sender;

            Exception ex = Server.GetLastError();



            HttpContext hc=


           Response.Redirect("Error");
        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            ISession S = CurrentSessionContext.Unbind(SF);
            S.Dispose();
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            ISession S = SF.OpenSession();
            CurrentSessionContext.Bind(S);
        }
    }
}
