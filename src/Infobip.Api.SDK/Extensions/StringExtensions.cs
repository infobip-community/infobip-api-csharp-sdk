using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.WebUtilities;

namespace Infobip.Api.SDK.Extensions
{
    /// <summary>
    /// Extensions for <see cref="string"/>.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Append the given query keys and values to the uri.
        /// </summary>
        /// <param name="uri">The base uri.</param>
        /// <param name="queryStringParameters">A collection of name value query pairs to append.</param>
        /// <returns>The combined result.</returns>
        public static string AddToQueryString(this string uri, IDictionary<string, object> queryStringParameters)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (queryStringParameters == null)
            {
                throw new ArgumentNullException(nameof(queryStringParameters));
            }

            var result = uri;

            foreach (var parameter in queryStringParameters)
            {
                var objValue = parameter.Value;
                if (objValue == null)
                {
                    continue;
                }

                if (objValue is int intValue)
                {
                    var value = GetValue(intValue);
                    result = AddQueryStringIfSpecified(result, parameter.Key, value);
                }
                else if (objValue is long longValue)
                {
                    var value = GetValue(longValue);
                    result = AddQueryStringIfSpecified(result, parameter.Key, value);
                }
                else if (objValue is string stringValue)
                {
                    var value = GetValue(stringValue);
                    result = AddQueryStringIfSpecified(result, parameter.Key, value);
                }
                else if (objValue is bool boolValue)
                {
                    var value = GetValue(boolValue);
                    result = AddQueryStringIfSpecified(result, parameter.Key, value);
                }
                else if (objValue is DateTime dateTimeValue)
                {
                    var value = GetValue(dateTimeValue);
                    result = AddQueryStringIfSpecified(result, parameter.Key, value);
                }
                else if (objValue is DateTimeOffset dateTimeOffsetValue)
                {
                    var value = GetValue(dateTimeOffsetValue);
                    result = AddQueryStringIfSpecified(result, parameter.Key, value);
                }
            }

            return result;
        }

        private static string GetValue(int value) => default == value ? null : value.ToString(CultureInfo.InvariantCulture);

        private static string GetValue(long value) => default == value ? null : value.ToString(CultureInfo.InvariantCulture);

        private static string GetValue(string value) => value;

        private static string GetValue(bool value) => default == value ? null : "true";

        private static string GetValue(DateTime? value) => value?.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        private static string GetValue(DateTimeOffset? value) => value?.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        private static string AddQueryStringIfSpecified(string uri, string name, string value) =>
            !string.IsNullOrEmpty(value) 
                ? QueryHelpers.AddQueryString(uri, name, value) 
                : uri;
    }
}
