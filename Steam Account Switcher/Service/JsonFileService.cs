using Newtonsoft.Json;
using System.IO;

namespace Steam_Account_Switcher
{
    public class JsonFileService : IFileService
    {
        public void Save<T>(string filename, T data)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        T IFileService.Read<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
        }
    }
}
