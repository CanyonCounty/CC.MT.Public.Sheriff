using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CC.MT.Public.Sheriff.Areas.HelpPage.ModelDescriptions
{
  /// <summary>
  /// ParameterDescription
  /// </summary>
  public class ParameterDescription
  {
    /// <summary>
    /// Default Constructor
    /// </summary>
    public ParameterDescription()
    {
      Annotations = new Collection<ParameterAnnotation>();
    }

    /// <summary>
    /// Annotations
    /// </summary>
    public Collection<ParameterAnnotation> Annotations { get; private set; }

    /// <summary>
    /// Documentation
    /// </summary>
    public string Documentation { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Type Description
    /// </summary>
    public ModelDescription TypeDescription { get; set; }
  }
}