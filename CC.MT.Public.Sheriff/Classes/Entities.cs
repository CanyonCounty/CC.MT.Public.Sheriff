using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.MT.Public.Sheriff
{
  /// <summary>
  /// Wait time queues at the DMV
  /// </summary>
  public class EntitiesList : List<Entities> { }

  /// <summary>
  /// Entities
  /// </summary>
  public class Entities
  {
    /// <summary>
    /// The Entity ID
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// The Office Name
    /// </summary>
    public string Office { get; set; }

    /// <summary>
    /// The Current Customer Wait Time in hh:mm:ss
    /// </summary>
    public string CustomerWaitTime { get; set; }

    /// <summary>
    /// The Maximum Customer Wait Time in hh:mm:ss
    /// </summary>
    public string MaxCustomerWaitTime { get; set; }

  }
}
