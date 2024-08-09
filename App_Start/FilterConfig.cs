using System.Web;
using System.Web.Mvc;

namespace AspMVCDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // HandleErrorAttribute handles errors globally
            filters.Add(new HandleErrorAttribute());

            // Add custom filters or global filters as needed
            // filters.Add(new AuthorizeAttribute());
        }
    }
}
