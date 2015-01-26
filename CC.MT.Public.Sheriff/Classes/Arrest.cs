using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CC.Common.Data;

namespace CC.MT.Sheriff.Data
{
  /// <summary>
  /// Containing Arrest Class
  /// </summary>
  public class Arrest
  {
    private string _agency;
    private DateTime _arrestDate;

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Arrest()
    {
      _agency = String.Empty;
      _arrestDate = CCData.DefaultDateTime;
    }

    /// <summary>
    /// The DataRow Constructor
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    public Arrest(DataRow row)
    {
      _agency = CCData.ToString(row["Agency"]);
      _arrestDate = CCData.ToDateTime(row["ArrestDate"]);
    }

    /// <summary>
    /// The Date the Arrest Took Place
    /// </summary>
    public string ArrestDate
    {
      get { return _arrestDate.ToString("g"); }
      set { _arrestDate = DateTime.Parse(value); }
    }

    /// <summary>
    /// The Agency that did the arrest (currently always blank)
    /// </summary>
    public string Agency
    {
      get { return _agency; }
      set { _agency = value; }
    }

    //public string Info
    //{
    //  get 
    //  {
    //    string ret = _arrestDate.ToString("g");
    //    if (!String.IsNullOrEmpty(_agency)) ret += " (" + _agency + ")";
    //    return ret;
    //  }
    //  set { }
    //}

    /// <summary>
    /// To String override
    /// </summary>
    /// <returns>The Arrest Info as a string</returns>
    public override String ToString()
    {
      string ret = _arrestDate.ToString("g");
      if (!String.IsNullOrEmpty(_agency)) ret += " (" + _agency + ")";
      return ret;      
      //return _arrestDate.ToString("g") + " - " + _agency;
    }

    /// <summary>
    /// Checks to see if the Arrest is equal to another one
    /// </summary>
    /// <param name="arrestDate">The Arrest Date</param>
    /// <param name="agency">The Arresting agency</param>
    /// <returns>True if they match</returns>
    public bool IsEqual(DateTime arrestDate, string agency)
    {
      return (arrestDate == this._arrestDate
        && agency == this._agency);
    }
  }
}
