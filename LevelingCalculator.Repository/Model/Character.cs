using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Repository.Model
{
    public class Character
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public int Stars { get; set; }

        public List<CharRes> char_ass { get; set; } = new List<CharRes>();
    }
}
