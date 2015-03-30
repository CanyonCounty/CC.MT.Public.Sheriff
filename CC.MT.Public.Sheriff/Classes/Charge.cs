using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CC.MT.Public.Sheriff
{
  /// <summary>
  /// Containing Charge Class
  /// </summary>
  public class Charge
  {
    //private string _description;
    //private string _statute;

    /// <summary>
    /// The default Constructor
    /// </summary>
    public Charge()
    {
      //_description = String.Empty;
      //_statute = String.Empty;
    }

    /// <summary>
    /// The DataRow Constructor
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    //public Charge(DataRow row)
    //{
    //  _description = CCData.ToString(row["ChargeDesc"]);
    //  _statute = CCData.ToString(row["ChargeStatute"]);
    //}

    /// <summary>
    /// The Statute Description
    /// </summary>
    public String StatuteDesc { get; set; }
    //{
    //  get { return _description; }
    //  set { _description = value; }
    //}

    /// <summary>
    /// The Statude Code
    /// </summary>
    public String StatuteCode { get; set; }
    //{
    //  get { return _statute; }
    //  set { _statute = value; }
    //}

    /// <summary>
    /// To String override
    /// </summary>
    /// <returns>The Arrest Info as a string</returns>
    //public override String ToString()
    //{
    //  return _statute + " - " + _description;// +" - " + _arrestDate.ToString("g") + " - " + _agency;
    //}

    /// <summary>
    /// Checks to see if the Arrest is equal to another one
    /// </summary>
    /// <param name="statute">The Statute</param>
    /// <param name="desc">The Description</param>
    /// <returns>True if they match</returns>
    //public bool IsEqual(string statute, string desc)
    //{
    //  return (statute == this.StatuteCode
    //    && desc == this.StatuteDesc);
    //}
  }
}
