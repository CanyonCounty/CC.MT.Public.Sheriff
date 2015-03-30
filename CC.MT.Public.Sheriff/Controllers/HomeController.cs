using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// HomeController
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// Index Action
    /// </summary>
    /// <returns>A Page or null and a Redirect</returns>
    public ActionResult Index()
    {
#if DEBUG
      string path = String.Empty;

      //path = "/CurrentArrest";
      //path = "/CurrentArrestString";
      path = "/JailList";
      //path = "/JailRosterByLetter/B";
      //path = "/JailRosterByLetter/-ALL";
      //path = "/JailRosterByName/Smith";
      //path = "/DMVWaitTime";
      //path = "/DMVWaitTimeQueue";

      Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + path);
      return null;
#else
      return View();
#endif
    }
  }
}
