using System;
using System.Reflection;

namespace CC.MT.Public.Sheriff.Areas.HelpPage.ModelDescriptions
{
  /// <summary>
  /// IModelDocumentationProvider
  /// </summary>
  public interface IModelDocumentationProvider
  {
    /// <summary>
    /// GetDocumentation
    /// </summary>
    /// <param name="member">MemberInfo</param>
    /// <returns>Documentation String</returns>
    string GetDocumentation(MemberInfo member);

    /// <summary>
    /// GetDocumentation
    /// </summary>
    /// <param name="type">Type</param>
    /// <returns>Documentation String</returns>
    string GetDocumentation(Type type);
  }
}