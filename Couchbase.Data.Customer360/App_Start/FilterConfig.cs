using System.Web;
using System.Web.Mvc;

namespace Couchbase.Data.Customer360
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
