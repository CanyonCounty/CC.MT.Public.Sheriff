using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace CC.MT.Public.Sheriff
{
  /// <summary>
  /// Public data on an individual in County Jail
  /// </summary>
  public class Inmate
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Inmate(): this(String.Empty){}

    /// <summary>
    /// Constructor that takes an error
    /// </summary>
    /// <param name="error">The error as to why we could not proceed</param>
    public Inmate(string error)
    {
    }
    
    /// <summary>
    /// A List of Charge <see cref="Charge"/>
    /// </summary>
    [DataMember]
    public ChargeList Charges { get; set; }

    /// <summary>
    /// The Inmate ID
    /// </summary>
    public String IDNumber { get; set; }

    /// <summary>
    /// A List of Arrest <see cref="Arrest"/>
    /// </summary>
    /// <seealso cref="Arrest"/>
    [DataMember]
    public ArrestList Arrests { get; set; }

    /// <summary>
    /// Inmates Last Name
    /// </summary>
    public String LastName { get; set; }

    /// <summary>
    /// Inmates First Name
    /// </summary>
    public String FirstName { get; set; }

    /// <summary>
    /// Inmates Middle Name
    /// </summary>
    public String MiddleName { get; set; }

    /// <summary>
    /// The VINE URL for Inmate
    /// </summary>
    public String VineURL { get; set; }

    /// <summary>
    /// The HTML link for the VINE URL
    /// </summary>
    [IgnoreDataMember]
    public String VineLink { get; set; }

    /// <summary>
    /// If set then there was an error in processing the request for data
    /// </summary>
    public String Error { get; set; }

    /// <summary>
    /// The URL to the thumbnail image
    /// </summary>
    public String ImageThumb { get; set; }

    /// <summary>
    /// The URL to the full sized image
    /// </summary>
    public String ImageFull { get; set; }

  }
}
