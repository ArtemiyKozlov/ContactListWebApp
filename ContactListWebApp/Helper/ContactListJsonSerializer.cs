using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ContactListWebApp.Helper
{
    public static class ContactListJsonSerializer
    {
        public static IEnumerable<ContactJson> Deserialize(string fullFilePath)
        {
            try
            {
                using (var reader = new StreamReader(fullFilePath))
                {
                    return JsonConvert.DeserializeObject<List<ContactJson>>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}