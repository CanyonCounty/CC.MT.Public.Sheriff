﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CC.MT.Proxy;
using Newtonsoft.Json;

namespace CC.MT.Public.Sheriff.Controllers
{
  /// <summary>
  /// Returns a Current Arrest List. This list is individuals that have been arrested in the past five days,
  /// sorted by arrest date with the most current being first (descending).
  /// This is different from CurrentArrest in that the Charges are a single string value delimited by a pipe "|" character.
  /// </summary>
  public class CurrentArrestStringController : ApiController
  {
    /// <summary>
    /// Get the Current Arrest List as strings
    /// </summary>
    /// <returns>A List of Inmates</returns>
    // <see cref="SampleDirection"/>
    public IQueryable<InmateString> GetCurrentArrests()
    {
      List<InmateString> list = new InmateStringList();
      try
      {
        CCProxy proxy = new CCProxy();
        string json = proxy.GetJSONFromPath("/Sheriff/CurrentArrestString");
        list = JsonConvert.DeserializeObject<List<InmateString>>(json);
      }
      catch (Exception e)
      {
        list.Add(new InmateString(e.Message));
      }
      return list.AsQueryable();
    }
  }
}
