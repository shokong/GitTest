using System.Web.Http;
using WebActivatorEx;
using CreditCard;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CreditCard
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "CreditCard");                        
                        c.IncludeXmlComments(string.Format(@"{0}\bin\CreditCard.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi();
        }
    }
}
