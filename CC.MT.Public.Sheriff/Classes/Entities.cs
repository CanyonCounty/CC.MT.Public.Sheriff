using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.MT.Sheriff.Tensator.Data
{
  /// <summary>
  /// A List of Entities
  /// </summary>
  public class EntitiesList : List<Entities> { }

  /// <summary>
  /// Entities
  /// </summary>
  public class Entities
  {
    private string _customerWaitTime;
    private string _maxCustomerWaitTime;

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
    public string CustomerWaitTime
    {
      set { _customerWaitTime = value; }
      get
      {
        double seconds = 0;
        Double.TryParse(_customerWaitTime, out seconds);
        TimeSpan ts = new TimeSpan(0, 0, (int)(seconds + 0.5));
        return ts.ToString();
      }
    }

    /// <summary>
    /// The Maximum Customer Wait Time in hh:mm:ss
    /// </summary>
    public string MaxCustomerWaitTime
    {
      set { _maxCustomerWaitTime = value; }
      get
      {
        double seconds = 0;
        Double.TryParse(_maxCustomerWaitTime, out seconds);
        TimeSpan ts = new TimeSpan(0, 0, (int)(seconds + 0.5));
        return ts.ToString();
      }
    }

  }
}
