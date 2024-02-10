using LevelingCalculator.Business.Abstraction;
using LevelingCalculator.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LevelingCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CharResController : ControllerBase
    {
        private readonly ILogger<CharResController> _logger;
        private readonly IBusiness _business;
        public CharResController(IBusiness business, ILogger<CharResController> logger)
        {
            _business = business;
            _logger = logger;
        }
        [HttpPost(Name = "AddCharRes")]
        public async Task<ActionResult> AddCharRes(CharResDTO charResDTO, CancellationToken cancellation = default)
        {
            await _business.AddCharRes(charResDTO, cancellation);
            return Ok("DONE!!!");
        }
        [HttpGet(Name = "GetCharacter")]
        public async Task<ActionResult<CharacterDTO?>> GetCharacter(int ID, CancellationToken cancellation = default)
        {
            CharacterDTO? character = await _business.GetCharacter(ID);
            return new JsonResult(character);
        }
        [HttpGet(Name = "GetResource")]
        public async Task<ActionResult<ResourceDTO?>> GetResource(int ID, CancellationToken cancellation = default)
        {
            ResourceDTO? resourceDTO = await _business.GetResource(ID);
            return new JsonResult(resourceDTO);
        }
        [HttpGet(Name = "GetCharRes")]
        public async Task<ActionResult<CharResDTO?>> GetCharRes(int ID, CancellationToken cancellation = default)
        {
            CharResDTO? charResDTO = await _business.GetCharRes(ID);
            return new JsonResult(charResDTO);
        }
        [HttpDelete(Name = "RemoveCharRes")]
        public async Task<ActionResult> RemoveCharRes(int ID, CancellationToken cancellation = default)
        {  
            await _business.RemoveCharRes(ID, cancellation);
            return Ok("DONE!!!");
        }
        [HttpPatch(Name = "UpdateCharRes")]
        public async Task<ActionResult> UpdateCharRes(CharResDTO charResDTO, CancellationToken cancellation = default)
        {
            await _business.UpdateCharRes(charResDTO, cancellation);
            return Ok("Done!!");
        }
        [HttpPatch(Name = "Ascend")]
        public async Task<ActionResult> Ascend(int charResID, CancellationToken cancellation = default)
        {
            await _business.Ascend(charResID, cancellation);
            return Ok("Done!!!");
        }
        [HttpPatch(Name = "LevelUP")]
        public async Task<ActionResult> LevelUp(int characterID, int actualLvl, CancellationToken cancellation = default)
        {
            await _business.LevelUP(characterID, actualLvl, cancellation);
            return Ok("Done!!!");
        }
    }
}
