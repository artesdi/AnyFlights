using Newtonsoft.Json;

namespace AnyFlights.Networking
{
    public class JsonDeserializer
    {
        public T Deserialize<T>(string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        } 
    }
}