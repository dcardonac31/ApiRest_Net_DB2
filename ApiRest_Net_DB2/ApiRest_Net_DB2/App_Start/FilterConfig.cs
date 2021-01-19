using System.Web;
using System.Web.Mvc;

namespace ApiRest_Net_DB2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
