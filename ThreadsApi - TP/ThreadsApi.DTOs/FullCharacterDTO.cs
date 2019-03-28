using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsApi.DTOs
{
    public class FullCharacterDTO
    {
        public int ID { get; set; }

        public int Pv { get; set; }

        public int PvMax { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public string Name { get; set; }
    }
}
