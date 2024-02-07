using LevelingCalculator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Business.Abstraction
{
    public interface IBusiness
    {
        Task AddCharRes(CharResDTO charResDTO, CancellationToken cancellation = default);
        Task RemoveCharRes(int ID, CancellationToken cancellation = default);
        Task<CharacterDTO?> GetCharacter(int ID, CancellationToken cancellation = default);
        Task<ResourceDTO?> GetResource(int ID, CancellationToken cancellation = default);
        Task<CharResDTO?> GetCharRes(int ID, CancellationToken cancellation = default);

    }
}
