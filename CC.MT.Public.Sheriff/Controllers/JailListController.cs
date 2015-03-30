using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CC.MT.Proxy;
using Newtonsoft.Json;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Returns a Jail List. A Jail List being the first letter of the last name of individuals currently in County Jail. 
  /// If a letter of the alphabet is missing from this list that means no one is in Jail with a last name
  /// that starts with that letter.
  /// </summary>
  public class JailListController : ApiController
  {
    /// <summary>
    /// Get the current Jail List
    /// </summary>
    /// <returns>A List of first letters or the last name of individuals currently in Jail. A missing letter means no one by that letter of last name is currently in jail.</returns>
    public IQueryable<string> GetJailList()
    {
      List<string> list = new List<string>();
      try
      {
        CCProxy proxy = new CCProxy();
        string json = proxy.GetJSONFromPath("/Sheriff/JailList");
        list = JsonConvert.DeserializeObject<List<string>>(json);
      }
      catch (Exception e)
      {
        list.Add(e.Message);
      }
      return list.AsQueryable();
    }
  }
}
