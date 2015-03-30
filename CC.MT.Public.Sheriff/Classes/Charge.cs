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
    /// <summary>
    /// The default Constructor
    /// </summary>
    public Charge()
    {
    }

    /// <summary>
    /// The Statute Description
    /// </summary>
    public String StatuteDesc { get; set; }

    /// <summary>
    /// The Statude Code
    /// </summary>
    public String StatuteCode { get; set; }
  }
}
