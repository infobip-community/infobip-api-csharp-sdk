using System;

namespace Infobip.Api.SDK.Attributes
{
    /// <summary>
    /// Marks property to be set as Query Parameter with given name and property name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class QueryParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameterAttribute" /> class with the specified name .
        /// </summary>
        /// <param name="parameterName">Name of the query parameter.</param>
        public QueryParameterAttribute(string parameterName) => ParameterName = parameterName;

        /// <summary>Gets or sets the name of the query parameter.</summary>
        /// <value>The name of the query parameter.</value>
        public string ParameterName { get; set; }
    }
}
