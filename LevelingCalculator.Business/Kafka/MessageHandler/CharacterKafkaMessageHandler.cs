using AutoMapper;
using Character.Shared;
using LevelingCalculator.Repository.Abstraction;
using LevelingCalculator.Repository.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Kafka.MessageHandlers;

namespace LevelingCalculator.Business.Kafka.MessageHandler
{
    public class CharacterKafkaMessageHandler : AbstractMessageHandler<CharacterDTO, CharacterKafka>
    {
        public CharacterKafkaMessageHandler(ILogger<CharacterKafkaMessageHandler> logger, IRepository repository, IMapper mapper) : base(logger, repository, mapper)
        {
        }

        protected override async Task DeleteDtoAsync(CharacterKafka domainDto, CancellationToken cancellationToken = default)
        {
            await Repository.RemoveCharacter(new LevelingCalculator.Repository.Model.Character
            {
                ID = domainDto.ID,
                Nome = domainDto.Name,
                Stars = domainDto.Star,
            }, cancellationToken);
        }

        protected override async Task InsertDtoAsync(CharacterKafka domainDto, CancellationToken cancellationToken = default)
        {
            await Repository.AddCharacter(new LevelingCalculator.Repository.Model.Character
            {
                ID = domainDto.ID,
                Nome = domainDto.Name,
                Stars = domainDto.Star,
            }, cancellationToken);
        }

        protected override async Task UpdateDtoAsync(CharacterKafka domainDto, CancellationToken cancellationToken = default)
        {
            await Repository.UpdateCharacter(new LevelingCalculator.Repository.Model.Character
            {
                ID = domainDto.ID,
                Nome = domainDto.Name,
                Stars = domainDto.Star,
            }, cancellationToken);
        }
    }
}
