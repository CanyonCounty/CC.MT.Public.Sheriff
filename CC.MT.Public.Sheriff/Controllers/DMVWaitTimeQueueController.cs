using System;
using System.Collections.Generic;
using System.Web.Http;
using CC.MT.Proxy;
using Newtonsoft.Json;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Individual wait time queues at the DMV.
  /// </summary>
  public class DMVWaitTimeQueueController : ApiController
  {
    /// <summary>
    /// Get the individual wait time queues at the DMV
    /// </summary>
    /// <returns>Returns the current wait time by queue and wait times. Currently there are 20 or so queues. Key is the queue name and value is the current wait time.</returns>
    public Dictionary<string, string> GetDMVWaitTimeQueue()
    {
      Dictionary<string, string> list = new Dictionary<string, string>();
      try
      {
        CCProxy proxy = new CCProxy();
        string json = proxy.GetJSONFromPath("/Sheriff/DMVWaitTimeQueue");
        list = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
      }
      catch (Exception e)
      {
        list.Add("error", e.Message);
      }
      return list;//.AsQueryable();
    }
  }
}
