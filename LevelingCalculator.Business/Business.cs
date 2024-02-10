using LevelingCalculator.Business.Abstraction;
using LevelingCalculator.Repository.Abstraction;
using LevelingCalculator.Repository.Model;
using LevelingCalculator.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Business
{
    public class Business : IBusiness
    {
        private readonly IRepository _repository;
        private readonly Character.ClientHTTP.Abstraction.IClientHTTP _characterHTTP;
        private readonly Resource.ClientHTTP.Abstraction.IClientHTTP _resourceHTTP;
        private readonly ILogger<Business> _logger;
        public Business(IRepository repository, ILogger<Business> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // AGGIUNTA
        public async Task AddCharRes(CharResDTO charResDTO, CancellationToken cancellation = default)
        {
            CharRes charRes = new CharRes
            {
                Elite = charResDTO.Elite,
                IDChar = charResDTO.IDChar,
                IDRes1 = charResDTO.IDRes1,
                IDRes2 = charResDTO.IDRes2,
                IDRes3 = charResDTO.IDRes3,
                ResN1 = charResDTO.ResN1,
                ResN2 = charResDTO.ResN2,
                ResN3 = charResDTO.ResN3,
                LMD = charResDTO.LMD

            };
            await _repository.AddCharRes(charRes, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task Ascend(int ID, CancellationToken cancellation = default)
        {
            CharResDTO? charRes = await GetCharRes(ID, cancellation);
            if (charRes != null) 
            {
                _resourceHTTP.ModifyOwn(charRes.IDRes1, -charRes.ResN1, cancellation);
                _resourceHTTP.ModifyOwn(charRes.IDRes2, -charRes.ResN2, cancellation);
                _resourceHTTP.ModifyOwn(charRes.IDRes3, -charRes.ResN3, cancellation);
                _characterHTTP.Ascend(charRes.IDChar, cancellation);
            }

        }

        // LETTURA
        public async Task<CharacterDTO?> GetCharacter(int ID, CancellationToken cancellation = default)
        {
            LevelingCalculator.Repository.Model.Character? character = await _repository.GetCharacter(ID, cancellation);
            if (character == null) return null;
            return new CharacterDTO
            {
                ID = character.ID,
                Nome = character.Nome,
                Stars = character.Stars,
            };
        }
        public async Task<CharResDTO?> GetCharRes(int ID, CancellationToken cancellation = default)
        {
            CharRes? charRes = await _repository.GetCharRes(ID, cancellation);
            if (charRes == null) return null;
            return new CharResDTO
            {
                ID = charRes.ID,
                Elite = charRes.Elite,
                IDChar = charRes.IDChar,
                IDRes1 = charRes.IDRes1,
                IDRes2 = charRes.IDRes2,
                IDRes3 = charRes.IDRes3,
                ResN1 = charRes.ResN1,
                ResN2 = charRes.ResN2,
                ResN3 = charRes.ResN3,
                LMD = charRes.LMD,
            };
        }
        public async Task<ResourceDTO?> GetResource(int ID, CancellationToken cancellation = default)
        {
            LevelingCalculator.Repository.Model.Resource? resource = await _repository.GetResource(ID, cancellation);
            if (resource == null) return null;
            return new ResourceDTO
            {
                ID = resource.ID,
                Nome = resource.Nome,
                Craftable = resource.Craftable,
                Own = resource.Own
            };
        }

        public async Task LevelUP(int ID, int actualLvl, CancellationToken cancellation = default)
        {
            await _characterHTTP.LevelUP(ID, actualLvl, cancellation);
        }

        // RIMOZIONE
        public async Task RemoveCharRes(int ID, CancellationToken cancellation = default)
        {
            CharRes? charRes = await _repository.GetCharRes(ID, cancellation);
            if (charRes == null) return;
            await _repository.RemoveCharRes(charRes, cancellation);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateCharRes(CharResDTO charResDTO, CancellationToken cancellation = default)
        {
            await _repository.UpdateCharRes(new CharRes
            {
                ID = charResDTO.ID,
                Elite = charResDTO.Elite,
                IDChar = charResDTO.IDChar,
                IDRes1 = charResDTO.IDRes1,
                IDRes2 = charResDTO.IDRes2,
                IDRes3 = charResDTO.IDRes3,
                ResN1 = charResDTO.ResN1,
                ResN2 = charResDTO.ResN2,
                ResN3 = charResDTO.ResN3,
                LMD = charResDTO.LMD
            }, cancellation);
            await _repository.SaveChangesAsync();
        }
    }
}
