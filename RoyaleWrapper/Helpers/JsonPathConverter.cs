using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace RoyaleWrapper.Helpers {
    public class JsonPathConverter : JsonConverter {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jo = JObject.Load(reader);
            var targetObj = Activator.CreateInstance(objectType);

            foreach (var prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite)) {
                var attr = prop.GetCustomAttribute<JsonPropertyAttribute>(true);

                var jsonPath = (attr != null ? attr.PropertyName : prop.Name);
                if (serializer.ContractResolver is DefaultContractResolver resolver)
                    jsonPath = resolver.GetResolvedPropertyName(jsonPath);

                var token = jo.SelectToken(jsonPath);
                if (token != null && token.Type != JTokenType.Null) {
                    var value = token.ToObject(prop.PropertyType, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }

            return targetObj;
        }

        public override bool CanConvert(Type objectType) => false;
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
