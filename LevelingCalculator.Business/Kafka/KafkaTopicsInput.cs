using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Business.Kafka
{
    public class KafkaTopicsInput : AbstractKafkaTopics
    {
        public string Resource { get; set; } = "Resource";
        public string Character { get; set; } = "Character";
        public override IEnumerable<string> GetTopics()
        {
            return new List<string>() { Resource, Character };
        }
    }
}
