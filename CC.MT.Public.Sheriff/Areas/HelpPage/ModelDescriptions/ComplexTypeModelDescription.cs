using System.Collections.ObjectModel;

namespace CC.MT.Public.Sheriff.Areas.HelpPage.ModelDescriptions
{
  /// <summary>
  /// Complex Type Model Description
  /// </summary>
  public class ComplexTypeModelDescription : ModelDescription
  {
    /// <summary>
    /// Complex Type Model Description
    /// </summary>
    public ComplexTypeModelDescription()
    {
      Properties = new Collection<ParameterDescription>();
    }

    /// <summary>
    /// Properties
    /// </summary>
    public Collection<ParameterDescription> Properties { get; private set; }
  }
}