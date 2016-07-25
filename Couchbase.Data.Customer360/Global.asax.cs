using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Couchbase.Configuration;
using Couchbase;
using Couchbase.Configuration.Client;

namespace Couchbase.Data.Customer360
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
         //   GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ClientConfiguration config = new ClientConfiguration
            {
                Servers = new List<Uri>
              {
                new Uri("http://97.105.9.202/pools")
              },
                            UseSsl = false,
                            DefaultOperationLifespan = 10000,
                            BucketConfigs = new Dictionary<string, BucketConfiguration>
                  {
                    {"default", new BucketConfiguration
                    {
                      BucketName = "default",
                      UseSsl = false,
                      UseEnhancedDurability=true,
     
                      Password = "",
                      DefaultOperationLifespan = 20000,
                      PoolConfiguration = new PoolConfiguration
                      {
                        MaxSize = 20,
                        MinSize = 1,
                        SendTimeout = 120000
                      }
                    }}
                 }
            };
            ClusterHelper.Initialize(config);
        }

    }
}
