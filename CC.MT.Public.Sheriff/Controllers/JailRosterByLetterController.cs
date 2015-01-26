using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
//using CC.MT.Sheriff.Data;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Jail Roster are those individuals currently in the County Jail
  /// </summary>
  public class JailRosterByLetterController : ApiController
  {
    /// <summary>
    /// Returns the current jail roster of individuals with a last name matching the first character of {id}
    /// </summary>
    /// <param name="id">The First Letter of the Last Name</param>
    /// <returns>A List or Array of Individuals matching {id}. If no {id} is passed it defaults to "A"</returns>
    public IQueryable<Inmate> GetJailRosterByLetter(string id = "A")
    {
      List<Inmate> list = new InmateList();
      try
      {
        WebClient client = new WebClient();
        if (id.Length >= 1)
        {
          //id = id[0].ToString();
          // The middle-tier is already only using the first char
          byte[] raw = client.DownloadData("http://ccmtprod08.canyonco.org/Sheriff/JailRosterByLetter/" + id);
          string json = Encoding.UTF8.GetString(raw);
          list = JsonConvert.DeserializeObject<List<Inmate>>(json);
        }
      }
      catch (Exception e)
      {
        list.Add(new Inmate(e.Message));
      }
      return list.AsQueryable();
    }
  }
}
