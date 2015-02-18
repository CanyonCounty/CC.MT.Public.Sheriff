using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;

namespace CC.MT.Public.Sheriff
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  /// <summary>
  /// WebApiApplication
  /// </summary>
  public class WebApiApplication : System.Web.HttpApplication
  {
    /// <summary>
    /// Application_Start
    /// </summary>
    protected void Application_Start()
    {
      // Only want UTF-8 thank you very much
      //for (int i = 1; i < GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedEncodings.Count; i++)
      //{
      //  GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedEncodings.RemoveAt(i);
      //}
      //var data = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedEncodings;

      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
      //camecase names
      //json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }
}