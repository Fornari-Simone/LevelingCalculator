using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Kafka.Abstractions.MessageHandlers;
using Utility.Kafka.Services;

namespace LevelingCalculator.Business.Kafka.MessageHandler.Factory
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly ILogger<ConsumerService<KafkaTopicsInput>> _logger;
        private readonly KafkaTopicsInput _topicsInput;
        public MessageHandlerFactory(ILogger<ConsumerService<KafkaTopicsInput>> logger, IOptions<KafkaTopicsInput> options)
        {
            _logger = logger;
            _topicsInput = options.Value;
        }
        public IMessageHandler Create(string topic, IServiceProvider serviceProvider)
        {
            if (topic == _topicsInput.Resource)
            {
                return ActivatorUtilities.CreateInstance<ResourceKafkaMessageHandler>(serviceProvider);
            } if (topic == _topicsInput.Character)
            {
                return ActivatorUtilities.CreateInstance<CharacterKafkaMessageHandler>(serviceProvider);
            }
            throw new ArgumentOutOfRangeException(nameof(topic), $"{topic} non gestito");
        }
    }
}
