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
  /// Jail Roster are those individuals currently in the County Jail
  /// </summary>
  public class JailRosterByNameController : ApiController
  {
    /// <summary>
    /// Returns the current jail roster of individuals with a name matching {id} (First or Last)
    /// </summary>
    /// <param name="id">The First or Last Name of the individual</param>
    /// <returns>A List of Inmate that match {id}</returns>
    public IQueryable<Inmate> GetJailRosterByName(string id)
    {
      List<Inmate> list = new InmateList();
      try
      {
        WebClient client = new WebClient();
        byte[] raw = client.DownloadData("http://ccmtprod08.canyonco.org/Sheriff/JailRosterByName/" + id);
        string json = Encoding.UTF8.GetString(raw);
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

