using System;
using System.Web.Http;
using System.Web.Mvc;
using CC.MT.Public.Sheriff.Areas.HelpPage.ModelDescriptions;
using CC.MT.Public.Sheriff.Areas.HelpPage.Models;

namespace CC.MT.Public.Sheriff.Areas.HelpPage.Controllers
{
  /// <summary>
  /// The controller that will handle requests for the help page.
  /// </summary>
  public class HelpController : Controller
  {
    private const string ErrorViewName = "Error";

    /// <summary>
    /// Default Constructor
    /// </summary>
    public HelpController()
      : this(GlobalConfiguration.Configuration)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="config">Help Configuration</param>
    public HelpController(HttpConfiguration config)
    {
      Configuration = config;
    }

    /// <summary>
    /// Http Configuration
    /// </summary>
    public HttpConfiguration Configuration { get; private set; }

    /// <summary>
    /// Index Action
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
      ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
      return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
    }

    /// <summary>
    /// Api Action
    /// </summary>
    /// <param name="apiId"></param>
    /// <returns></returns>
    public ActionResult Api(string apiId)
    {
      if (!String.IsNullOrEmpty(apiId))
      {
        HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
        if (apiModel != null)
        {
          return View(apiModel);
        }
      }

      return View(ErrorViewName);
    }

    /// <summary>
    /// Resource Model Action
    /// </summary>
    /// <param name="modelName">model name</param>
    /// <returns>ActionResult</returns>
    public ActionResult ResourceModel(string modelName)
    {
      if (!String.IsNullOrEmpty(modelName))
      {
        ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
        ModelDescription modelDescription;
        if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
        {
          return View(modelDescription);
        }
      }

      return View(ErrorViewName);
    }
  }
}