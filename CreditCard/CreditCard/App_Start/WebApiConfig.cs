using System.Web.Http;

namespace CreditCard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "Validation",
               routeTemplate: "api/{controller}/Validation"
           );
        }
    }
}
