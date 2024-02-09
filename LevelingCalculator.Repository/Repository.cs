using LevelingCalculator.Repository.Abstraction;
using LevelingCalculator.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Repository
{
    public class Repository : IRepository
    {
        private LevelingCalculatorDbContext _dbContext;
        public Repository(LevelingCalculatorDbContext levelingCalculatorDbContext) 
        { 
            _dbContext = levelingCalculatorDbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        { 
            return await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task AddCharacter(Character character, CancellationToken cancellation = default)
        {
            await _dbContext.Character.AddAsync(character, cancellation);
        }

        public async Task AddCharRes(CharRes charRes, CancellationToken cancellation = default)
        {
            await _dbContext.CharRes.AddAsync(charRes, cancellation);
        }

        public async Task AddResource(Resource resource, CancellationToken cancellation = default)
        {
            await _dbContext.Resource.AddAsync(resource, cancellation);
        }

        public async Task<Character?> GetCharacter(int ID, CancellationToken cancellation = default)
        {
            return await _dbContext.Character.FindAsync(ID, cancellation);
        }

        public async Task<Resource?> GetResource(int ID, CancellationToken cancellation = default)
        {
            return await _dbContext.Resource.FindAsync(ID, cancellation);
        }

        public async Task<CharRes?> GetCharRes(int ID, CancellationToken cancellation = default)
        {
            return await _dbContext.CharRes.FindAsync(ID, cancellation);
        }

        public async Task RemoveCharacter(Character car, CancellationToken cancellation = default)
        {
            _dbContext.Character.Remove(car);
        }

        public async Task RemoveResource(Resource res, CancellationToken cancellation = default)
        {
            _dbContext.Resource.Remove(res);
        }

        public async Task RemoveCharRes(CharRes cr, CancellationToken cancellation = default)
        {
            _dbContext.CharRes.Remove(cr);
        }

        public async Task UpdateCharacter(Character character, CancellationToken cancellation = default)
        {
            Character? character1 = await this.GetCharacter(character.ID, cancellation);
            if (character1 != null)
            {
                character1.Nome = character.Nome;
            }
        }

        public async Task UpdateResource(Resource resource, CancellationToken cancellation = default)
        {
            Resource? resource1 = await this.GetResource(resource.ID, cancellation);
            if (resource1 != null)
            {
                resource1.Nome = resource.Nome;
                resource1.Craftable = resource.Craftable;
                resource1.Own = resource.Own;
            }
        }

        public async Task UpdateCharRes(CharRes charRes, CancellationToken cancellation = default)
        {
            CharRes? charRes1 = await this.GetCharRes(charRes.ID, cancellation);
            if (charRes1 != null)
            {
                charRes1.Elite = charRes.Elite;
                charRes1.IDChar = charRes.IDChar;
                charRes1.IDRes1 = charRes.IDRes1;
                charRes1.IDRes2 = charRes.IDRes2;
                charRes1.IDRes3 = charRes.IDRes3;
                charRes1.ResN1 = charRes.ResN1;
                charRes1.ResN2 = charRes.ResN2;
                charRes1.ResN3 = charRes.ResN3;
                charRes1.LMD = charRes.LMD;
            }
        }
    }
}
