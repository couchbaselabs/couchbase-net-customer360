using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Couchbase.Data.Customer360.Startup))]
namespace Couchbase.Data.Customer360
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
