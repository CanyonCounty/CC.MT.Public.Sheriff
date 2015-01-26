using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CC.MT.Public.Sheriff.Areas.HelpPage.ModelDescriptions
{
  /// <summary>
  /// Enum Type Model Description
  /// </summary>
  public class EnumTypeModelDescription : ModelDescription
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public EnumTypeModelDescription()
    {
      Values = new Collection<EnumValueDescription>();
    }

    /// <summary>
    /// Values
    /// </summary>
    public Collection<EnumValueDescription> Values { get; private set; }
  }
}