using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using CC.MT.Sheriff.Tensator.Data;
using System.Text;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Entities are the combiled wait times per department at the DMV
  /// </summary>
  public class EntitiesController : ApiController
  {
    /// <summary>
    /// Get the EntitiesServices
    /// </summary>
    /// <returns>A List of Entities</returns>
    public IQueryable<Entities> GetEntitiesServices()
    {
      List<Entities> list = new EntitiesList();
      try
      {
        WebClient client = new WebClient();
        byte[] raw = client.DownloadData("http://ccmtprod08.canyonco.org/Sheriff/Entities");
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
