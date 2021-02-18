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
                var json = GetRepository("Data/RebelsRepository.json");
                return JsonConvert.DeserializeObject<IEnumerable<Rebel>>(json);
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

        public void AddRebel(RebelParams rebel)
        {
            try
            {
                var json = GetRepository("Data/RebelsRepository.json");
                Rebel newRebel = new Rebel(rebel.Name, rebel.Planet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private string GetRepository(string path)
        {
            var filepath = Path.GetFullPath(path);
            return File.ReadAllText(filepath);
        }


    }
}
