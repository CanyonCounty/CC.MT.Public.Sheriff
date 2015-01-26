using System;

namespace CC.MT.Public.Sheriff.Areas.HelpPage.ModelDescriptions
{
  /// <summary>
  /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
  public sealed class ModelNameAttribute : Attribute
  {
    /// <summary>
    /// ModelNameAttributes
    /// </summary>
    /// <param name="name">name</param>
    public ModelNameAttribute(string name)
    {
      Name = name;
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; private set; }
  }
}