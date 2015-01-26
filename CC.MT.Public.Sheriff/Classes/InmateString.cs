﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CC.Common.Data;

namespace CC.MT.Public.Sheriff
{
  /// <summary>
  /// Public data on an individual in County Jail
  /// </summary>
  public class InmateString
  {
    private const string _server = "http://images.canyonco.org";
    
    //private string _agency;
    //private DateTime _arrestDate;    
    private string _number;
    private string _lastName;
    private string _firstName;
    private string _middleName;
    private string _chargeList;
    private string _arrestList;
    private string _timestamp;
    private string _error;
    private string _system;
    private string _thumb;
    private string _image;

    /// <summary>
    /// Default Constructor
    /// </summary>
    public InmateString() : this(String.Empty) { }

    /// <summary>
    /// Constructor that takes an error
    /// </summary>
    /// <param name="error">The error as to why we could not proceed</param>
    public InmateString(string error)
    {
      //_agency = String.Empty;
      //_arrestDate = CCData.DefaultDateTime;

      _number = String.Empty;
      _lastName = String.Empty;
      _firstName = String.Empty;
      _middleName = String.Empty;
      _chargeList = String.Empty;
      _arrestList = String.Empty;
      _timestamp = String.Empty;
      _system = String.Empty;

      _error = error;
    }

    /// <summary>
    /// The Real Constructor
    /// </summary>
    /// <param name="row">The DataRow to pull data from</param>
    /// <param name="system">The current system in use</param>
    public InmateString(DataRow row, string system)
    {
      //_agency = CCData.ToString(row["Agency"]);
      //_arrestDate = CCData.ToDateTime(row["ArrestDate"]);
      _number = CCData.ToString(row["Number"]).Trim();
      _lastName = CCData.ToString(row["LastName"]).Trim();
      _firstName = CCData.ToString(row["FirstName"]).Trim();
      _middleName = CCData.ToString(row["MiddleName"]).Trim();
      _timestamp = CCData.ToString(row["ImageName"]).Trim().Split('.')[0];
      _chargeList = String.Empty;
      _arrestList = String.Empty;
      _error = String.Empty;
      _system = system;

      //AddCharge(row);
      //AddArrest(row);
    }

    //public void AddCharge(DataRow row)
    //{
    //  Charge charge = new Charge(row);
    //  _chargeList.Add(charge);
    //}

    //public void AddCharge(Charge charge)
    //{
    //  _chargeList.Add(charge);
    //}

    //public void AddArrest(DataRow row)
    //{
    //  Arrest arrest = new Arrest(row);
    //  _arrestList.Add(arrest);
    //}

    //public void AddArrest(Arrest arrest)
    //{
    //  _arrestList.Add(arrest);
    //}

    /// <summary>
    /// A List of <see cref="Charge"/>
    /// </summary>
    public String Charges
    {
      get { return _chargeList; }
      set { _chargeList = value; }
    }

    /// <summary>
    /// The Inmate ID
    /// </summary>
    public String IDNumber
    {
      get { return _number; }
      set { _number = value; }
    }

    /// <summary>
    /// A List of <see cref="Arrest"/>
    /// </summary>
    /// <seealso cref="Arrest"/>
    public String Arrests
    {
      get { return _arrestList; }
      set { _arrestList = value; }
    }

    /// <summary>
    /// Inmates Last Name
    /// </summary>
    public String LastName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }

    /// <summary>
    /// Inmates First Name
    /// </summary>
    public String FirstName
    {
      get { return _firstName; }
      set { _firstName = value; }
    }

    /// <summary>
    /// Inmates Middle Name
    /// </summary>
    public String MiddleName
    {
      get { return _middleName; }
      set { _middleName = value; }
    }

    //public String FirstLastName
    //{
    //  get { return _firstName + " " + _lastName; }
    //  set { }
    //}

    //public String LastFirstName
    //{
    //  get { return _lastName + ", " + _firstName; }
    //  set { }
    //}

    //public String FirstMiddleLastName
    //{
    //  get { return _firstName + " " + _middleName + " " + _lastName; }
    //  set { }
    //}

    //public String LastFirstMiddleName
    //{
    //  get { return _lastName + ", " + _firstName + " " + _middleName; }
    //  set { }
    //}

    /// <summary>
    /// The VINE URL for Inmate
    /// </summary>
    public String VineURL
    {
      get 
      {
        if (String.IsNullOrEmpty(_error))
          return "http://www.vinelink.com/servlet/SubjectSearch?siteID=13000&agency=15&offenderID=" + _number;
        else
          return String.Empty;
      }
      set { }
    }

    /// <summary>
    /// The HTML link for the VINE URL
    /// </summary>
    public String VineLink
    {
      get
      {
        if (String.IsNullOrEmpty(_error))
          return "<a title=\"External Link - VINELink Victum Notification Service.\" href=\"" + VineURL + "\" target=\"_blank\">Receive Change of Status Updates</a>";
        else
          return String.Empty;
      }
      set { }
    }

    /// <summary>
    /// If set then there was an error in processing the request for data
    /// </summary>
    public String Error
    {
      get { return _error; }
      set { _error = value; }
    }

    /// <summary>
    /// The URL to the thumbnail image
    /// </summary>
    public String ImageThumb
    {
      get 
      {
        if (_thumb == null)
        {
          if (!String.IsNullOrEmpty(_system))
          {
            if (String.IsNullOrEmpty(_timestamp))
              return String.Format("{0}/ImgSvc/?sys={1}&id={2}.thumb", _server, _system, _number);
            else
              return String.Format("{0}/ImgSvc/?sys={1}&ts={2}&id={3}.thumb", _server, _system, _timestamp, _number);
          }
          else
          {
            return String.Empty;
          }
        }
        else
        {
          return _thumb;
        }
      }
      set { _thumb = value; }
    }

    /// <summary>
    /// The URL to the full sized image
    /// </summary>
    public String ImageFull
    {
      get
      {
        if (_image == null)
        {
          if (!String.IsNullOrEmpty(_system))
          {
            if (String.IsNullOrEmpty(_timestamp))
              return String.Format("{0}/ImgSvc/?sys={1}&id={2}.full", _server, _system, _number);
            else
              return String.Format("{0}/ImgSvc/?sys={1}&ts={2}&id={3}.full", _server, _system, _timestamp, _number);
          }
          else
          {
            return String.Empty;
          }
        }
        else
        {
          return _image;
        }
      }

      set { _image = value; }
    }

    /// <summary>
    /// Just the string representation of Inmate
    /// </summary>
    /// <returns>A Simple string of id - first middle last name</returns>
    public override String ToString()
    {
      return _number + " - " + _firstName + " " + _middleName + " " + _lastName;
    }

    //public bool HaveCharge(string statute, string desc)
    //{
    //  return _chargeList.ContainsCharge(statute, desc);
    //}

    //public bool HaveCharge(DataRow row)
    //{
    //  return _chargeList.ContainsCharge(row);
    //}

    //public bool HaveArrest(DateTime arrestDate, string agency)
    //{
    //  return _arrestList.ContainsArrest(arrestDate, agency);
    //}

    //public bool HaveArrest(DataRow row)
    //{
    //  return _arrestList.ContainsArrest(row);
    //}

    /// <summary>
    /// Tests to see if the Inmate is Equal
    /// </summary>
    /// <param name="id">The ID to test for</param>
    /// <returns>True if they are equal</returns>
    public bool IsEqual(string id)
    {
      return (id == this.IDNumber);
    }
  }
}