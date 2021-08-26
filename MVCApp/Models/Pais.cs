using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVCApp.Models
{
    public class Pais
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Pais> GetCountriesList(string root)
        {
            string path =$"{root}\\Data\\iso-countries.json";
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Pais>>(json);
        }
    }
}
