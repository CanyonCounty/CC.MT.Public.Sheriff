using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CC.MT.Public.Sheriff
{
  /// <summary>
  /// Containing Arrest Class
  /// </summary>
  public class Arrest
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Arrest()
    {
    }

    /// <summary>
    /// The Date the Arrest Took Place
    /// </summary>
    public string ArrestDate { get; set; }

    /// <summary>
    /// The Agency that did the arrest (currently always blank)
    /// </summary>
    public string Agency { get; set; }

  }
}
