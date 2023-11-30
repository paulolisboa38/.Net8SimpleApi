using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHerosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SuperHerosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _dataContext.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if(hero is null)
            {
                return BadRequest();
            }
            return Ok(hero);
        }
    }
}
