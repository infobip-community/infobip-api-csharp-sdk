using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Extensions
{
    /// <summary>
    /// Extensions for <see cref="MultipartFormDataContent"/>.
    /// </summary>
    internal static class MultiPartFormDataContentExtensions
    {
        /// <summary>
        /// Add given object properties as HTTP content to a collection of HttpContent objects that get serialized to multipart/form-data MIME type to a <see cref="MultipartFormDataContent"/> instance.
        /// </summary>
        /// <remarks>
        /// <see cref="JsonPropertyAttribute"/> is used to mark properties that are going to be added to a <see cref="MultipartFormDataContent"/> instance.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="multipartFormDataContent">The <see cref="MultipartFormDataContent"/> instance</param>
        /// <param name="data">An object whose properties are added.</param>
        /// <exception cref="NotSupportedException"></exception>
        public static void Add<T>(this MultipartFormDataContent multipartFormDataContent, T data)
            where T : class
        {
            foreach (var propertyInfo in data.GetType().GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttributes(false)
                    .OfType<JsonPropertyAttribute>()
                    .FirstOrDefault();

                if (attribute == null)
                {
                    continue;
                }


                if (propertyInfo.PropertyType == typeof(int?))
                {
                    if (propertyInfo.GetValue(data) is int value)
                    {
                        multipartFormDataContent.Add(new StringContent(value.ToString(CultureInfo.InvariantCulture)),
                            attribute.PropertyName);
                    }

                    continue;
                }


                if (propertyInfo.PropertyType == typeof(bool?))
                {
                    if (propertyInfo.GetValue(data) is bool value)
                    {
                        multipartFormDataContent.Add(new StringContent(value.ToString(CultureInfo.InvariantCulture)),
                            propertyInfo.Name);
                    }

                    continue;
                }

                if (propertyInfo.PropertyType == typeof(DateTime?))
                {
                    if (propertyInfo.GetValue(data) is DateTime value)
                    {
                        multipartFormDataContent.Add(new StringContent(value.ToString("yyyy-MM-ddTHH:mm:ss.fffK")),
                            propertyInfo.Name);
                    }

                    continue;
                }

                if (propertyInfo.PropertyType == typeof(string))
                {
                    if (propertyInfo.GetValue(data) is string value)
                    {
                        multipartFormDataContent.Add(new StringContent(value), propertyInfo.Name);
                    }

                    continue;
                }

                if (propertyInfo.PropertyType == typeof(Stream))
                {
                    if (propertyInfo.GetValue(data) is Stream value)
                    {
                        multipartFormDataContent.Add(new StreamContent(value), propertyInfo.Name, propertyInfo.Name);
                    }

                    continue;
                }

                // For other property types throw NotSupportedException. 
                throw new NotSupportedException($"PropertyType is not supported. Type: {propertyInfo.PropertyType}");
            }
        }
    }
}
