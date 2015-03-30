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
        if (id.Length >= 1)
        {
          // The middle-tier is already only using the first char
          CCProxy proxy = new CCProxy();
          string json = proxy.GetJSONFromPath("/Sheriff/JailRosterByLetter/" + id);
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
