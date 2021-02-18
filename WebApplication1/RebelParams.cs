using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireEye
{
    public class RebelParams
    {
        public string Name { get; set; }
        public string Planet { get; set; }

        public RebelParams(string Name, string Planet)
        {
            this.Name = Name;
            this.Planet = Planet;
        }
    }
}
