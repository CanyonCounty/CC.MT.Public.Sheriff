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
        WebClient client = new WebClient();
        byte[] raw = client.DownloadData("http://ccmtprod08.canyonco.org/Sheriff/DMVWaitTime");
        string json = Encoding.UTF8.GetString(raw);
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
