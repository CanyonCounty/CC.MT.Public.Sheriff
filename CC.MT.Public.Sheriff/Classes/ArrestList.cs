using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CC.Common.Data;

namespace CC.MT.Sheriff.Data
{
  /// <summary>
  /// A List of <see cref="Arrest"/>
  /// </summary>
  public class ArrestList : List<Arrest>
  {
    /// <summary>
    /// Checks to see if the Arrest Exists already
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    /// <returns>True if it exists in the list</returns>
    public bool ContainsArrest(DataRow row)
    {
      string agency = CCData.ToString(row["Agency"]);
      DateTime arrestDate = CCData.ToDateTime(row["ArrestDate"]);
      return ContainsArrest(arrestDate, agency);
    }

    /// <summary>
    /// Checks to see if the Arrest Exists already
    /// </summary>
    /// <param name="arrestDate">The Arrest Date</param>
    /// <param name="agency">And Agengy to check for</param>
    /// <returns>True if it exists in the list</returns>
    public bool ContainsArrest(DateTime arrestDate, string agency)
    {
      bool ret = false;
      foreach (Arrest arrest in this)
      {
        if (arrest.IsEqual(arrestDate, agency))
        {
          return true;
        }
      }
      return ret;
    }
  }
}
