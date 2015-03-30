using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CC.MT.Proxy;
using Newtonsoft.Json;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Returns a Current Arrest List. This list is individuals that have been arrested in the past five days,
  /// sorted by arrest date with the most current being first (descending).
  /// </summary>
  public class CurrentArrestController : ApiController
  {
    /// <summary>
    /// Get the Current Arrest List
    /// </summary>
    /// <returns>A List of Inmate</returns>
    // <see cref="Inmate"/>
    public IQueryable<Inmate> GetCurrentArrests()
    {
      List<Inmate> list = new InmateList();
      try
      {
        CCProxy proxy = new CCProxy();
        string json = proxy.GetJSONFromPath("/Sheriff/CurrentArrest");
        list = JsonConvert.DeserializeObject<List<Inmate>>(json);
      }
      catch (Exception e)
      {
        list.Add(new Inmate(e.Message));
      }
      return list.AsQueryable();
    }
  }
}
