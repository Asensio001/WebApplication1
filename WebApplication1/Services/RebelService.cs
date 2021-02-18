using EmpireEye;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class RebelService : IRebelService
    {
        public IEnumerable<Rebel> GetRebels()
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<Rebel>>(GetRepository("Data/RebelsRepository.json"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetRebel(string rebel)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<IEnumerable<Rebel>>(GetRepository("Data/RebelsRepository.json"));
                return json.First(x => x.Name == rebel).Planet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRebel()
        {
            try
            {
                var path = "Data/RebelsRepository.json";
                var json = GetRepository(path);
                var list = JsonConvert.DeserializeObject<List<Rebel>>(json);
                list.Add(new Rebel("newRebel", "Earth"));

                var jsonToOutput = JsonConvert.SerializeObject(list, Formatting.Indented);
                saveList(jsonToOutput,path);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void saveList(string jsonToOutput, string path)
        {
            System.IO.File.WriteAllText(path, jsonToOutput);
        }

        private string GetRepository(string path)
        {
            var filepath = Path.GetFullPath(path);
            return File.ReadAllText(filepath);
        }


    }
}
