﻿using System.Text.Json;

namespace CSharpFunctionalExtensions
{
    public static class JsonSerializerOptionsExtensionMethods
    {
        public static JsonSerializerOptions AddCSharpFunctionalExtensionsConverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new ResultJsonConverter());
            options.Converters.Add(new ResultJsonConverterFactory());
            return options;
        }
    }
}
