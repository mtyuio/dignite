﻿using Dignite.Abp.FieldCustomizing.FieldControls;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

namespace Dignite.Abp.FieldCustomizing.EntityFrameworkCore.ValueConverters
{
    public  class CustomizedFieldControlConfigurationValueConverter : ValueConverter<FieldControlConfigurationDictionary, string>
    {
        public CustomizedFieldControlConfigurationValueConverter()
            : base(
                d => SerializeObject(d),
                s => DeserializeObject(s))
        {

        }

        private static string SerializeObject(FieldControlConfigurationDictionary extraProperties)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
            };
            return JsonSerializer.Serialize(extraProperties, serializeOptions);
        }

        private static FieldControlConfigurationDictionary DeserializeObject(string extraPropertiesAsJson)
        {
            if (extraPropertiesAsJson.IsNullOrEmpty() || extraPropertiesAsJson == "{}")
            {
                return new FieldControlConfigurationDictionary();
            }

            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new ObjectToInferredTypesConverter());

            var dictionary = JsonSerializer.Deserialize<FieldControlConfigurationDictionary>(extraPropertiesAsJson, deserializeOptions) ??
                             new FieldControlConfigurationDictionary();


            return dictionary;
        }

    }
}
