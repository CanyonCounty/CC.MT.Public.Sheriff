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
    //private const string _server = "http://images.canyonco.org";
    
    //private string _agency;
    //private DateTime _arrestDate;    
    //private string _number;
    //private string _lastName;
    //private string _firstName;
    //private string _middleName;
    //private ChargeList _chargeList;
    //private ArrestList _arrestList;
    //private string _timestamp;
    //private string _error;
    //private string _system;
    //private string _thumb;
    //private string _image;

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
      //_agency = String.Empty;
      //_arrestDate = CCData.DefaultDateTime;

      //_number = String.Empty;
      //_lastName = String.Empty;
      //_firstName = String.Empty;
      //_middleName = String.Empty;
      //_chargeList = new ChargeList();
      //_arrestList = new ArrestList();
      //_timestamp = String.Empty;
      ////_system = "sh42";

      //_error = error;
    }

    /// <summary>
    /// The Real Constructor
    /// </summary>
    /// <param name="row">The DataRow to pull data from</param>
    /// <param name="system">The current system in use</param>
    //public Inmate(DataRow row, string system)
    //{
    //  //_agency = CCData.ToString(row["Agency"]);
    //  //_arrestDate = CCData.ToDateTime(row["ArrestDate"]);
    //  _number = CCData.ToString(row["Number"]).Trim();
    //  _lastName = CCData.ToString(row["LastName"]).Trim();
    //  _firstName = CCData.ToString(row["FirstName"]).Trim();
    //  _middleName = CCData.ToString(row["MiddleName"]).Trim();
    //  _timestamp = CCData.ToString(row["ImageName"]).Trim().Split('.')[0];
    //  _chargeList = new ChargeList();
    //  _arrestList = new ArrestList();
    //  _error = String.Empty;
    //  _system = system;

    //  AddCharge(row);
    //  AddArrest(row);
    //}

    /// <summary>
    /// Adds a DataRow Charge
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    //public void AddCharge(DataRow row)
    //{
    //  Charge charge = new Charge(row);
    //  _chargeList.Add(charge);
    //}

    /// <summary>
    /// Adds a DataRow Arrest
    /// </summary>
    /// <param name="row">The DataRow to pull information from</param>
    //public void AddArrest(DataRow row)
    //{
    //  Arrest arrest = new Arrest(row);
    //  _arrestList.Add(arrest);
    //}

    /// <summary>
    /// A List of Charge <see cref="Charge"/>
    /// </summary>
    [DataMember]
    public ChargeList Charges { get; set; }
    //{
    //  get { return _chargeList; }
    //  set { _chargeList = value; }
    //}

    /// <summary>
    /// The Inmate ID
    /// </summary>
    public String IDNumber { get; set; }
    //{
    //  get { return _number; }
    //  set { _number = value; }
    //}

    /// <summary>
    /// A List of Arrest <see cref="Arrest"/>
    /// </summary>
    /// <seealso cref="Arrest"/>
    [DataMember]
    public ArrestList Arrests { get; set; }
    //{
    //  get { return _arrestList; }
    //  set { _arrestList = value; }
    //}

    /// <summary>
    /// Inmates Last Name
    /// </summary>
    public String LastName { get; set; }
    //{
    //  get { return _lastName; }
    //  set { _lastName = value; }
    //}

    /// <summary>
    /// Inmates First Name
    /// </summary>
    public String FirstName { get; set; }
    //{
    //  get { return _firstName; }
    //  set { _firstName = value; }
    //}

    /// <summary>
    /// Inmates Middle Name
    /// </summary>
    public String MiddleName { get; set; }
    //{
    //  get { return _middleName; }
    //  set { _middleName = value; }
    //}

    /// <summary>
    /// The VINE URL for Inmate
    /// </summary>
    public String VineURL { get; set; }
    //{
    //  get 
    //  {
    //    if (String.IsNullOrEmpty(_error))
    //      return "http://www.vinelink.com/servlet/SubjectSearch?siteID=13000&agency=15&offenderID=" + _number;
    //    else
    //      return String.Empty;
    //  }
    //  set { }
    //}

    /// <summary>
    /// The HTML link for the VINE URL
    /// </summary>
    [IgnoreDataMember]
    public String VineLink { get; set; }
    //{
    //  get
    //  {
    //    if (String.IsNullOrEmpty(_error))
    //      return "<a title=\"External Link - VINELink Victum Notification Service.\" href=\"" + VineURL + "\" target=\"_blank\">Receive Change of Status Updates</a>";
    //    else
    //      return String.Empty;
    //  }
    //  set { }
    //}

    /// <summary>
    /// If set then there was an error in processing the request for data
    /// </summary>
    public String Error { get; set; }
    //{
    //  get { return _error; }
    //  set { _error = value; }
    //}

    /// <summary>
    /// The URL to the thumbnail image
    /// </summary>
    public String ImageThumb { get; set; }
    //{
    //  get 
    //  {
    //    if (_thumb == null)
    //    {
    //      if (!String.IsNullOrEmpty(_system))
    //      {
    //        if (String.IsNullOrEmpty(_timestamp))
    //          return String.Format("{0}/ImgSvc/?sys={1}&id={2}.thumb", _server, _system, _number);
    //        else
    //          return String.Format("{0}/ImgSvc/?sys={1}&ts={2}&id={3}.thumb", _server, _system, _timestamp, _number);
    //      }
    //      else
    //      {
    //        return String.Empty;
    //      }
    //    }
    //    else
    //    {
    //      return _thumb;
    //    }
    //  }
    //  set { _thumb = value; }
    //}

    /// <summary>
    /// The URL to the full sized image
    /// </summary>
    public String ImageFull { get; set; }
    //{
    //  get
    //  {
    //    if (_image == null)
    //    {
    //      if (!String.IsNullOrEmpty(_system))
    //      {
    //        if (String.IsNullOrEmpty(_timestamp))
    //          return String.Format("{0}/ImgSvc/?sys={1}&id={2}.full", _server, _system, _number);
    //        else
    //          return String.Format("{0}/ImgSvc/?sys={1}&ts={2}&id={3}.full", _server, _system, _timestamp, _number);
    //      }
    //      else
    //      {
    //        return String.Empty;
    //      }
    //    }
    //    else
    //    {
    //      return _image;
    //    }
    //  }

    //  set { _image = value; }
    //}

    /// <summary>
    /// Just the string representation of Inmate
    /// </summary>
    /// <returns>A Simple string of id - first middle last name</returns>
    //public override String ToString()
    //{
    //  return _number + " - " + _firstName + " " + _middleName + " " + _lastName;
    //}

    /// <summary>
    /// Tests to see if the Inmate is Equal
    /// </summary>
    /// <param name="id">The ID to test for</param>
    /// <returns>True if they are equal</returns>
    //public bool IsEqual(string id)
    //{
    //  return (id == this.IDNumber);
    //}
  }
}
