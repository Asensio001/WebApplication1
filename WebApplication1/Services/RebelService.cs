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

        public Rebel GetRebel(string rebel)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<IEnumerable<Rebel>>(GetRepository("Data/RebelsRepository.json"));
                return json.First(x => x.Name == rebel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRebel(RebelParams rebel)
        {
            try
            {
                var path = "Data/RebelsRepository.json";
                var json = GetRepository(path);
                var list = JsonConvert.DeserializeObject<List<Rebel>>(json);
                list.Add(new Rebel(rebel.Name, rebel.Planet));

                var jsonToOutput = JsonConvert.SerializeObject(list, Formatting.Indented);
                SaveList(jsonToOutput,path);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateRebel(RebelParams rebel)
        {
            var path = "Data/RebelsRepository.json";
            var list = GetRebels(path);
            var rebelUpdate = list.First(x => x.Name == rebel.Name);
            if (rebelUpdate != null)
            {
                rebelUpdate.Name = rebel.Name;
                rebelUpdate.Planet = rebel.Planet;
                rebelUpdate.Date = DateTime.Now;
            }
            var jsonToOutput = JsonConvert.SerializeObject(list, Formatting.Indented);
            SaveList(jsonToOutput, path);
        }

        private void SaveList(string jsonToOutput, string path)
        {
            System.IO.File.WriteAllText(path, jsonToOutput);
        }

        private string GetRepository(string path)
        {
            var filepath = Path.GetFullPath(path);
            return File.ReadAllText(filepath);
        }

        private List<Rebel> GetRebels(string path)
        {
            var filepath = Path.GetFullPath(path);
            return JsonConvert.DeserializeObject<List<Rebel>>(File.ReadAllText(filepath));

        }


    }
}
