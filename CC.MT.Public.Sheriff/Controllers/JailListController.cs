using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using CC.MT.Sheriff.Data;

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
    /// <returns>A List of letters of individuals currently in Jail</returns>
    public IQueryable<string> GetJailList()
    {
      List<string> list = new List<string>();
      try
      {
        WebClient client = new WebClient();
        byte[] raw = client.DownloadData("http://ccmtprod08.canyonco.org/Sheriff/JailList");
        string json = Encoding.UTF8.GetString(raw);
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
