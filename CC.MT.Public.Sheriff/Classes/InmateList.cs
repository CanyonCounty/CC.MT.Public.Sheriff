using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CC.Common.Data;

namespace CC.MT.Sheriff.Data
{
  /// <summary>
  /// A List of <see cref="Inmate"/>
  /// </summary>
  public class InmateList : List<Inmate>
  {
    //public bool ContainsInmate(DataRow row)
    //{
    //  bool ret = false;
    //  string number = CCData.ToString(row["Number"]).Trim();
    //  foreach(Inmate inmate in this)
    //  {
    //    if (inmate.IsEqual(number))
    //    {
    //      return true;
    //    }
    //  }
    //  return ret;
    //}

    /// <summary>
    /// Returns the matching Inmate for the current DataRow
    /// </summary>
    /// <param name="row">The DataRow to pull the id from</param>
    /// <returns>a new "empty" Inmate or the one that's found</returns>
    public Inmate GetInmate(DataRow row)
    {
      Inmate ret = new Inmate();
      string number = CCData.ToString(row["Number"]).Trim();
      foreach (Inmate inmate in this)
      {
        if (inmate.IsEqual(number))
        {
          ret = inmate;
          break;
        }
      }
      return ret;
    }
  }
}
