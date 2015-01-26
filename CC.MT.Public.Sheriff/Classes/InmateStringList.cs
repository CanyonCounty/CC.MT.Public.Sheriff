using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CC.Common.Data;

namespace CC.MT.Public.Sheriff
{
  /// <summary>
  /// A List of <see cref="InmateString"/>
  /// </summary>
  public class InmateStringList : List<InmateString>
  {
    //public InmateString GetInmate(DataRow row)
    //{
    //  InmateString ret = new InmateString();
    //  string number = CCData.ToString(row["Number"]).Trim();
    //  foreach (InmateString inmate in this)
    //  {
    //    if (inmate.IsEqual(number))
    //    {
    //      ret = inmate;
    //      break;
    //    }
    //  }
    //  return ret;
    //}
  }
}
