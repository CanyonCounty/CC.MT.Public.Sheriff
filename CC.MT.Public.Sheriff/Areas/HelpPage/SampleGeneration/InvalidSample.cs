using System;

namespace CC.MT.Public.Sheriff.Areas.HelpPage
{
  /// <summary>
  /// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
  /// </summary>
  public class InvalidSample
  {
    /// <summary>
    /// Invalid Sample
    /// </summary>
    /// <param name="errorMessage">error message string</param>
    public InvalidSample(string errorMessage)
    {
      if (errorMessage == null)
      {
        throw new ArgumentNullException("errorMessage");
      }
      ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Error Message
    /// </summary>
    public string ErrorMessage { get; private set; }

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="obj">object</param>
    /// <returns>bool</returns>
    public override bool Equals(object obj)
    {
      InvalidSample other = obj as InvalidSample;
      return other != null && ErrorMessage == other.ErrorMessage;
    }

    /// <summary>
    /// GetHashCode
    /// </summary>
    /// <returns>ErrorMessage Hash Code</returns>
    public override int GetHashCode()
    {
      return ErrorMessage.GetHashCode();
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Error Message</returns>
    public override string ToString()
    {
      return ErrorMessage;
    }
  }
}