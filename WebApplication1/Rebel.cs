using System;

namespace WebApplication1
{
    public class Rebel
    {
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string Planet { get; set; }

        public Rebel(string Name, string Planet)
        {
            this.Name = Name;
            this.Planet = Planet;
            this.Date = DateTime.Now;
        }

    }
}
