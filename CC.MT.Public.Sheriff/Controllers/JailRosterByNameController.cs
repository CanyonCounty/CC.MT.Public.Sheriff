using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CC.MT.Proxy;
using Newtonsoft.Json;

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
        CCProxy proxy = new CCProxy();
        string json = proxy.GetJSONFromPath("/Sheriff/JailRosterByName/" + id);
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

