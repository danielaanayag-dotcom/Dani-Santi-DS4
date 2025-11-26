using System.Web.Http;

namespace ApiCalculadora
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configurar JSON como formato predeterminado
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // Remover el formateador XML para que solo devuelva JSON
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}