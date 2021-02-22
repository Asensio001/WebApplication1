using EmpireEye;
using System.Collections.Generic;

namespace WebApplication1.Services
{
    public interface IRebelService
    {
        public IEnumerable<Rebel> GetRebels();
        public Rebel GetRebel(string rebel);
        public void AddRebel(RebelParams rebel);
        public void UpdateRebel(RebelParams rebel);
    }
}