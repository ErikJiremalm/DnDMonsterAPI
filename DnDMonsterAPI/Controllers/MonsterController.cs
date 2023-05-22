using DnDMonsterAPI.Services.MonsterServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DnDMonsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly IMonsterServices _monsterServices;
        public MonsterController(IMonsterServices monsterServices)
        {
            _monsterServices = monsterServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Monster>> GetAMonster(int id)
        {
            var result = await _monsterServices.GetAMonster(id);
            if (result is null)
                return NotFound("detta monster fins inte än");
            return Ok(result);

        }
        [HttpGet]
        public async Task<ActionResult<List<Monster>>>  GetAllMonsters()
        {
            return await _monsterServices.GetAllMonsters();
        }
        [HttpPost]

        public async Task<ActionResult<List<Monster>>> AddAMonster(Monster newMonster)
        {
            var result = await _monsterServices.AddAMonster(newMonster);
            return Ok(result);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Monster>>> UpdateAMonster(int id, Monster request)
        {
            var result = await _monsterServices.UpdateAMonster(id,request);
            if (result is null)
                return NotFound("detta monster fins inte än");
            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Monster>>> DeleteAMonster(int id)
        {
            var result = await _monsterServices.DeleteAMonster(id);
            if (result is null)
                return NotFound("detta monster fins inte än");
            return Ok(result);
        }
    }
}
