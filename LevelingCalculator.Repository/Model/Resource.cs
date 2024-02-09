using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Repository.Model
{
    public class Resource
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public int Craftable { get; set; } = 0;
        public int Own { get; set; } = 0;

        public List<CharRes> res_ass { get; set; } = new List<CharRes>();
    }
}
