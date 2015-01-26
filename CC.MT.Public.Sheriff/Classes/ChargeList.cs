using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CC.Common.Data;

namespace CC.MT.Sheriff.Data
{
  /// <summary>
  /// A List of <see cref="Charge"/>
  /// </summary>
  public class ChargeList : List<Charge>
  {
    /// <summary>
    /// Checks to see if the Charge Exists already
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    /// <returns>True if it exists in the list</returns>
    public bool ContainsCharge(DataRow row)
    {
      string statute = CCData.ToString(row["ChargeStatute"]).Trim();
      string desc = CCData.ToString(row["ChargeDesc"]).Trim();
      return ContainsCharge(statute, desc);
    }

    /// <summary>
    /// Checks to see if the Charge Exists already
    /// </summary>
    /// <param name="statute">The Statute to check for</param>
    /// <param name="desc">As well as the Description</param>
    /// <returns>True if it exists in the list</returns>
    public bool ContainsCharge(string statute, string desc)
    {
      bool ret = false;
      foreach (Charge charge in this)
      {
        if (charge.IsEqual(statute, desc))
        {
          return true;
        }
      }
      return ret;
    }

    /// <summary>
    /// GetCharge
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    /// <returns>A Created Charge</returns>
    public Charge GetCharge(DataRow row)
    {
      Charge ret = new Charge();
      string statute = CCData.ToString(row["ChargeStatute"]).Trim();
      string desc = CCData.ToString(row["ChargeDesc"]).Trim();
      foreach (Charge charge in this)
      {
        if (charge.IsEqual(statute, desc))
        {
          ret = charge;
          break;
        }
      }
      return ret;
    }
  }
}
