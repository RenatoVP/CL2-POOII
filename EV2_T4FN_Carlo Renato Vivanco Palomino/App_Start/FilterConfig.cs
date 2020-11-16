using System.Web;
using System.Web.Mvc;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
