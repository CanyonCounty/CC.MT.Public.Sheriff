using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CC.MT.Proxy;
using Newtonsoft.Json;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Combiled wait time queues per department at the DMV
  /// </summary>
  public class DMVWaitTimeController : ApiController
  {
    /// <summary>
    /// Get the combiled wait time queues per department at the DMV
    /// </summary>
    /// <returns>A List of Entities</returns>
    public IQueryable<Entities> GetDMVWaitTime()
    {
      List<Entities> list = new EntitiesList();
      try
      {
        CCProxy proxy = new CCProxy();
        string json = proxy.GetJSONFromPath("/Sheriff/DMVWaitTime");
        list = JsonConvert.DeserializeObject<List<Entities>>(json);
      }
      catch //(Exception e)
      {
        //list.Add(new Entities(e.Message));
      }
      return list.AsQueryable();
    }
  }
}
