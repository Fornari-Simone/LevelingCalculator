using LevelingCalculator.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Repository.Abstraction
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
        Task AddCharacter(Character character, CancellationToken cancellation = default);
        Task AddResource(Resource resource, CancellationToken cancellation = default);
        Task AddCharRes(CharRes charRes, CancellationToken cancellation = default);
        Task<Character?> GetCharacter(int ID, CancellationToken cancellation = default);
        Task<Resource?> GetResource(int ID, CancellationToken cancellation = default);
        Task<CharRes?> GetCharRes(int ID, CancellationToken cancellation = default);
        Task RemoveCharacter(Character car, CancellationToken cancellation = default);
        Task RemoveResource(Resource res, CancellationToken cancellation = default);
        Task RemoveCharRes(CharRes cr, CancellationToken cancellation = default);
    }
}
