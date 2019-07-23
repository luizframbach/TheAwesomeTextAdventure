using System;

namespace TheAwesomeTextAdventure.Infrastructure.Serializers.Abstractions
{
    public interface ICustomSerialization
    {
        string Serialize<TRequest>(TRequest content);
        object Deserialize(string content, Type typeExpected);
    }
}