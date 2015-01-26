using System;

namespace CC.MT.Public.Sheriff.Areas.HelpPage
{
  /// <summary>
  /// This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
  /// </summary>
  public class TextSample
  {
    /// <summary>
    /// TextSample
    /// </summary>
    /// <param name="text">text</param>
    public TextSample(string text)
    {
      if (text == null)
      {
        throw new ArgumentNullException("text");
      }
      Text = text;
    }

    /// <summary>
    /// Text
    /// </summary>
    public string Text { get; private set; }

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="obj">object</param>
    /// <returns>bool</returns>
    public override bool Equals(object obj)
    {
      TextSample other = obj as TextSample;
      return other != null && Text == other.Text;
    }

    /// <summary>
    /// GetHashCode
    /// </summary>
    /// <returns>Text hash code</returns>
    public override int GetHashCode()
    {
      return Text.GetHashCode();
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Text</returns>
    public override string ToString()
    {
      return Text;
    }
  }
}