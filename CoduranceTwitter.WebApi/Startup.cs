using System.Net.Http.Headers;
using System.Web.Http;
using Owin;

namespace CoduranceTwitter.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{username}/{data}",
                defaults: new { data = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web Api
            app.UseWebApi(config);
        }
    }
}
