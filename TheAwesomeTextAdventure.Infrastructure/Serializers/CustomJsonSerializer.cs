using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions;

namespace TheAwesomeTextAdventure.Infrastructure.Serializers
{
    [ExcludeFromCodeCoverage]
    public class CustomJsonSerializer : ICustomSerialization
    {
        public string Serialize<TRequest>(TRequest content)
        {
            return JsonConvert.SerializeObject(content, Settings);
        }

        public object Deserialize(string content, Type typeExpected)
        {
            return JsonConvert.DeserializeObject(content, typeExpected, Settings);
        }

        private JsonSerializerSettings Settings => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
