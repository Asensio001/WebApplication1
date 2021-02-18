using EmpireEye;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public interface IRebelService
    {
        public IEnumerable<Rebel> GetRebels();
        public string GetRebel(string rebel);
        public void AddRebel(RebelParams rebel);
    }
}