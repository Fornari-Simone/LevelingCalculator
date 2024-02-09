using AutoMapper;
using LevelingCalculator.Repository.Abstraction;
using LevelingCalculator.Repository.Model;
using Microsoft.Extensions.Logging;
using Resource.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Kafka.MessageHandlers;

namespace LevelingCalculator.Business.Kafka.MessageHandler
{
    public class ResourceKafkaMessageHandler : AbstractMessageHandler<ResourceDTO, ResourceKafka>
    {
        public ResourceKafkaMessageHandler(ILogger<ResourceKafkaMessageHandler> logger, IRepository repository, IMapper mapper) : base(logger, repository, mapper)
        {
        }

        protected override async Task DeleteDtoAsync(ResourceKafka domainDto, CancellationToken cancellation = default)
        {
            await Repository.RemoveResource(new LevelingCalculator.Repository.Model.Resource
            {
                ID = domainDto.ID,
                Nome = domainDto.Name,
                Craftable = domainDto.Craftable,
                Own = domainDto.Own
            }, cancellation);
        }

        protected override async Task InsertDtoAsync(ResourceKafka domainDto, CancellationToken cancellation = default)
        {
            await Repository.AddResource(new LevelingCalculator.Repository.Model.Resource
            {
                ID = domainDto.ID,
                Nome = domainDto.Name,
                Craftable = domainDto.Craftable,
                Own = domainDto.Own
            }, cancellation);
        }

        protected override async Task UpdateDtoAsync(ResourceKafka domainDto, CancellationToken cancellationToken = default)
        {
            await Repository.UpdateResource(new LevelingCalculator.Repository.Model.Resource
            {
                ID = domainDto.ID,
                Nome = domainDto.Name,
                Craftable = domainDto.Craftable,
                Own = domainDto.Own
            }, cancellationToken);
        }
    }
}
