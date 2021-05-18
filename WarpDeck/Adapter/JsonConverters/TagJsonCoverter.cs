using System;
using Newtonsoft.Json;
using WarpDeck.Domain.Model;

namespace WarpDeck.Adapter.JsonConverters
{
    public class TagJsonCoverter : JsonConverter<TagModel>
    {
        public override void WriteJson(JsonWriter writer, TagModel value, JsonSerializer serializer)
        {
            writer.WriteValue(TagModel.ToTagString(value));
        }

        public override TagModel ReadJson(JsonReader reader, Type objectType, TagModel existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return TagModel.ParseTagString((string) reader.Value);
        }
    }
}