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
    }
}
