/*
 * Copyright (c) 2016 Mike Reust
 *
 * For details check https://github.com/reustmd/DataAnnotationsValidatorRecursive
 */


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Infobip.Api.SDK.Extensions;
#pragma warning disable CS1591

namespace Infobip.Api.SDK.Validation.DataAnnotations
{
    public class DataAnnotationsValidator : IDataAnnotationsValidator
    {
        public bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj, null, validationContextItems), results, true);
        }

        public bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return TryValidateObjectRecursive(obj, results, new HashSet<object>(), validationContextItems);
        }

        private bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, ISet<object> validatedObjects, IDictionary<object, object> validationContextItems = null)
        {
            // Short-circuit to avoid infinite loops on cyclical object graphs
            if (validatedObjects.Contains(obj))
            {
                return true;
            }

            validatedObjects.Add(obj);
            bool result = TryValidateObject(obj, results, validationContextItems);

            var properties = obj.GetType().GetProperties().Where(prop => prop.CanRead
                && !prop.GetCustomAttributes(typeof(SkipRecursiveValidation), false).Any()
                && prop.GetIndexParameters().Length == 0).ToList();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType) continue;

                var value = obj.GetPropertyValue(property.Name);

                if (value == null) continue;

                if (value is IEnumerable asEnumerable)
                {
                    foreach (var enumObj in asEnumerable)
                    {
                        if (enumObj != null)
                        {
                            var nestedResults = new List<ValidationResult>();
                            if (!TryValidateObjectRecursive(enumObj, nestedResults, validatedObjects, validationContextItems))
                            {
                                result = false;
                                foreach (var validationResult in nestedResults)
                                {
                                    PropertyInfo property1 = property;
                                    results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
                                }
                            };
                        }
                    }
                }
                else
                {
                    var nestedResults = new List<ValidationResult>();
                    if (!TryValidateObjectRecursive(value, nestedResults, validatedObjects, validationContextItems))
                    {
                        result = false;
                        foreach (var validationResult in nestedResults)
                        {
                            PropertyInfo property1 = property;
                            results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
                        }
                    };
                }
            }

            return result;
        }
    }
}