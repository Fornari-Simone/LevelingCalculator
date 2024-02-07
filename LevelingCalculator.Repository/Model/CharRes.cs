using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Repository.Model
{
    public class CharRes
    {
        public int ID { get; set; }
        public int Elite { get; set; }
        public int IDChar { get; set; }
        public int IDRes1 { get; set; }
        public int IDRes2 { get; set; }
        public int IDRes3 { get; set; }
        public int ResN1 { get; set; }
        public int ResN2 { get; set; }
        public int ResN3 { get; set; }
        public int LMD { get; set; }

        public Resource? resource { get; set; }
        public Character? character { get; set; }
    }
}
