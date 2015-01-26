using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
//using CC.MT.Sheriff.Tensator.Data;
using System.Text;

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
    public Dictionary<string, string> GetEntitiesServices()
    {
      Dictionary<string, string> list = new Dictionary<string, string>();
      try
      {
        WebClient client = new WebClient();
        byte[] raw = client.DownloadData("http://ccmtprod08.canyonco.org/Sheriff/EntitiesServices");
        string json = Encoding.UTF8.GetString(raw);
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
