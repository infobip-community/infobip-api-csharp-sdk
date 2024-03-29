﻿namespace Infobip.Api.SDK.Extensions
{
    /// <summary>
    /// Extensions for <see cref="object"/>.
    /// </summary>
    internal static class ObjectExtensions
    {
        public static object GetPropertyValue(this object o, string propertyName)
        {
            object objValue = string.Empty;

            var propertyInfo = o.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
                objValue = propertyInfo.GetValue(o, null);

            return objValue;
        }
    }
}