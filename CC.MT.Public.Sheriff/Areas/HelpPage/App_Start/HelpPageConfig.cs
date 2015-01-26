// Uncomment the following to provide samples for PageResult<T>. Must also add the Microsoft.AspNet.WebApi.OData
// package to your project.
//#define Handle_PageResultOfT

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
//using CC.MT.Sheriff.Data;
#if Handle_PageResultOfT
using System.Web.Http.OData;
#endif

namespace CC.MT.Public.Sheriff.Areas.HelpPage
{
  /// <summary>
  /// The Class to Hide Controllers from the documentation. They are still usable though.
  /// </summary>
  public class MyApiExplorer : ApiExplorer
  {
    /// <summary>
    /// Default Constructor, needed because .NET doesn't inherit constructors (like the rest of the world does)
    /// </summary>
    /// <param name="config">The HttpConfiguration</param>
    public MyApiExplorer(HttpConfiguration config)
      : base(config)
    {
    }
    
    /// <summary>
    /// Checks to see if the controller should be visible
    /// </summary>
    /// <param name="controllerVariableValue">The same as controllerDescriptor.ControllerName - lame</param>
    /// <param name="controllerDescriptor">Information about the controller</param>
    /// <param name="route">I dunno</param>
    /// <returns>false if you want it hidden</returns>
    public override bool ShouldExploreController(string controllerVariableValue, HttpControllerDescriptor controllerDescriptor, IHttpRoute route)
    {
      if (controllerVariableValue.Equals("CurrentArrestString")) // your logic to filter out API by route
      {
        return false;
      }

      return base.ShouldExploreController(controllerVariableValue, controllerDescriptor, route);
    }
  }
    
  /// <summary>
  /// Use this class to customize the Help Page.
  /// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
  /// or you can provide the samples for the requests/responses.
  /// </summary>
  public static class HelpPageConfig
  {
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="config">HttpConfiguration</param>
    [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "CC.MT.Public.Sheriff.Areas.HelpPage.TextSample.#ctor(System.String)",
        Justification = "End users may choose to merge this string with existing localized resources.")]
    [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "bsonspec",
        Justification = "Part of a URI.")]
    public static void Register(HttpConfiguration config)
    {
      Inmate inmate = new Inmate("Only set on the first record if there was an error. It will be the error message.");
      inmate.FirstName = "JOHN";
      inmate.LastName = "PUBLIC";
      inmate.MiddleName = "QUE";
      inmate.IDNumber = "000000";

      Arrest arrest = new Arrest();
      arrest.ArrestDate = DateTime.Today.ToString();
      arrest.Agency = "Currently Always Blank";
      inmate.Arrests = new ArrestList();
      inmate.Arrests.Add(arrest);

      Charge charge1 = new Charge();
      charge1.StatuteCode = "I18-2407(2)";
      charge1.StatuteDesc = "Theft Petit";
      Charge charge2 = new Charge();
      charge2.StatuteCode = "I20-222";
      charge2.StatuteDesc = "Probation Violation [F]";

      inmate.Charges = new ChargeList();
      inmate.Charges.Add(charge1);
      inmate.Charges.Add(charge2);

      InmateList inmateList = new InmateList();
      inmateList.Add(inmate);

      Entities entity = new Entities();
      entity.CustomerWaitTime = "00:09:30";
      entity.ID = "2";
      entity.MaxCustomerWaitTime = "00:21:45";
      entity.Office = "Canyon County DMV ASSESSOR";
      EntitiesList entityList = new EntitiesList();
      entityList.Add(entity);

      Dictionary<string, string> dict = new Dictionary<string,string>();
      dict.Add("New Registration", "00:09:59");
      dict.Add("Out-of-State Registation", "00:10:28");
      dict.Add("...", "Several additional queues");
      dict.Add("Driver's Training Permit", "00:27:22");

      config.Services.Replace(typeof(IApiExplorer), new MyApiExplorer(config));

      //// Uncomment the following to use the documentation from XML documentation file.
      config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));

      //// Uncomment the following to use "sample string" as the sample for all actions that have string as the body parameter or return type.
      //// Also, the string arrays will be used for IEnumerable<string>. The sample objects will be serialized into different media type 
      //// formats by the available formatters.
      config.SetSampleObjects(new Dictionary<Type, object>
      {
          {typeof(string), "sample string"},
          {typeof(IQueryable<string>), new string[]{"A", "B", "...", "W", "Y", "Z"}.AsQueryable()},
          {typeof(IQueryable<Inmate>), inmateList.AsQueryable()},
          {typeof(IQueryable<Entities>), entityList.AsQueryable()},
          {typeof(Dictionary<string, string>), dict}
      });

      // Extend the following to provide factories for types not handled automatically (those lacking parameterless
      // constructors) or for which you prefer to use non-default property values. Line below provides a fallback
      // since automatic handling will fail and GeneratePageResult handles only a single type.
#if Handle_PageResultOfT
            config.GetHelpPageSampleGenerator().SampleObjectFactories.Add(GeneratePageResult);
#endif

      // Extend the following to use a preset object directly as the sample for all actions that support a media
      // type, regardless of the body parameter or return type. The lines below avoid display of binary content.
      // The BsonMediaTypeFormatter (if available) is not used to serialize the TextSample object.
      config.SetSampleForMediaType(
          new TextSample("Binary JSON content. See http://bsonspec.org for details."),
          new MediaTypeHeaderValue("application/bson"));

      //// Uncomment the following to use "[0]=foo&[1]=bar" directly as the sample for all actions that support form URL encoded format
      //// and have IEnumerable<string> as the body parameter or return type.
      //config.SetSampleForType("[0]=foo&[1]=bar", new MediaTypeHeaderValue("application/x-www-form-urlencoded"), typeof(IEnumerable<string>));

      //// Uncomment the following to use "1234" directly as the request sample for media type "text/plain" on the controller named "Values"
      //// and action named "Put".
      //config.SetSampleRequest("1234", new MediaTypeHeaderValue("text/plain"), "Values", "Put");

      //// Uncomment the following to use the image on "../images/aspNetHome.png" directly as the response sample for media type "image/png"
      //// on the controller named "Values" and action named "Get" with parameter "id".
      //config.SetSampleResponse(new ImageSample("../images/aspNetHome.png"), new MediaTypeHeaderValue("image/png"), "Values", "Get", "id");

      //// Uncomment the following to correct the sample request when the action expects an HttpRequestMessage with ObjectContent<string>.
      //// The sample will be generated as if the controller named "Values" and action named "Get" were having string as the body parameter.
      //config.SetActualRequestType(typeof(string), "Values", "Get");

      //// Uncomment the following to correct the sample response when the action returns an HttpResponseMessage with ObjectContent<string>.
      //// The sample will be generated as if the controller named "Values" and action named "Post" were returning a string.
      //config.SetActualResponseType(typeof(string), "Values", "Post");
    }

#if Handle_PageResultOfT
        private static object GeneratePageResult(HelpPageSampleGenerator sampleGenerator, Type type)
        {
            if (type.IsGenericType)
            {
                Type openGenericType = type.GetGenericTypeDefinition();
                if (openGenericType == typeof(PageResult<>))
                {
                    // Get the T in PageResult<T>
                    Type[] typeParameters = type.GetGenericArguments();
                    Debug.Assert(typeParameters.Length == 1);

                    // Create an enumeration to pass as the first parameter to the PageResult<T> constuctor
                    Type itemsType = typeof(List<>).MakeGenericType(typeParameters);
                    object items = sampleGenerator.GetSampleObject(itemsType);

                    // Fill in the other information needed to invoke the PageResult<T> constuctor
                    Type[] parameterTypes = new Type[] { itemsType, typeof(Uri), typeof(long?), };
                    object[] parameters = new object[] { items, null, (long)ObjectGenerator.DefaultCollectionSize, };

                    // Call PageResult(IEnumerable<T> items, Uri nextPageLink, long? count) constructor
                    ConstructorInfo constructor = type.GetConstructor(parameterTypes);
                    return constructor.Invoke(parameters);
                }
            }

            return null;
        }
#endif
  }
}