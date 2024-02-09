using AutoMapper;
using LevelingCalculator.Repository.Abstraction;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Kafka.MessageHandlers;

namespace LevelingCalculator.Business.Kafka.MessageHandler.Abstraction
{
    public abstract class AbstractMessageHandler<TMessageDTO> : 
        AbstractOperationMessageHandler<TMessageDTO, IRepository> where TMessageDTO : class, new()
    {
        protected AbstractMessageHandler(ILogger<AbstractMessageHandler<TMessageDTO>> logger, IRepository repository) : base(logger, repository) { }

        protected override async Task DeleteAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Delete del DTO {messageDTOType}...", MessageDtoType);
            await DeleteDtoAsync(messageDto);
            await Repository.SaveChangesAsync();
            Logger.LogInformation("Delete del DTO {messageDTOType} completata", MessageDtoType);
        }

        protected override async Task InsertAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Adding DTO {messageDtoType}", MessageDtoType);
            await InsertDtoAsync(messageDto);
            await Repository.SaveChangesAsync();
            Logger.LogInformation("Adding DTO {messageDTOType}: done", MessageDtoType);
        }

        protected override async Task UpdateAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Update del DTO {messageDTOType}...", MessageDtoType);
            await UpdateDtoAsync(messageDto);
            await Repository.SaveChangesAsync();
            Logger.LogInformation("Update del DTO {messageDTOType} completata", MessageDtoType);
        }

        protected abstract Task InsertDtoAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default);
        protected abstract Task UpdateDtoAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default);
        protected abstract Task DeleteDtoAsync(TMessageDTO messageDto, CancellationToken cancellationToken = default);
    }
}

public abstract class AbstractMessageHandler<TMessageDTO, TDomainDTO> :
    AbstractOperationMessageHandler<TMessageDTO, TDomainDTO, IRepository>
    where TMessageDTO : class, new()
    where TDomainDTO : class, new()
{
    protected AbstractMessageHandler(ILogger<AbstractOperationMessageHandler<TMessageDTO, TDomainDTO, IRepository>> logger, IRepository repository, IMapper mapper) : base(logger, repository, mapper)
    {
    }
    protected override async Task InsertAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Insert del DTO {domainDTOType}...", DomainDtoType);
        await InsertDtoAsync(domainDto, cancellationToken);
        await Repository.SaveChangesAsync();
        Logger.LogInformation("Insert del DTO {domainDTOType} completata!", DomainDtoType);
    }

    protected override async Task UpdateAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Update del DTO {domainDTOType}...", DomainDtoType);
        await UpdateDtoAsync(domainDto, cancellationToken);
        await Repository.SaveChangesAsync();
        Logger.LogInformation("Update del DTO {domainDTOType} completata", DomainDtoType);
    }

    protected override async Task DeleteAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default)
    {
        Logger.LogInformation("Delete del DTO {domainDTOType}...", DomainDtoType);
        await DeleteDtoAsync(domainDto, cancellationToken);
        await Repository.SaveChangesAsync();
        Logger.LogInformation("Delete del DTO {domainDTOType} completata", DomainDtoType);
    }

    protected abstract Task InsertDtoAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default);

    protected abstract Task UpdateDtoAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default);

    protected abstract Task DeleteDtoAsync(TDomainDTO domainDto, CancellationToken cancellationToken = default);
}
