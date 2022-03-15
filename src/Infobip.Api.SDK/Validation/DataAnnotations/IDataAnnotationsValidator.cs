/*
 * Copyright (c) 2016 Mike Reust
 *
 * For details check https://github.com/reustmd/DataAnnotationsValidatorRecursive
 */


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS1591

namespace Infobip.Api.SDK.Validation.DataAnnotations
{
    public interface IDataAnnotationsValidator
    {
        bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object> validationContextItems = null);
        bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null);
    }
}