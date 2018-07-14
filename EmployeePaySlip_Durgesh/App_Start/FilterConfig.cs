using System.Web;
using System.Web.Mvc;

namespace EmployeePaySlip_Durgesh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
