using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
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

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHeroDto hero)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newHero = new SuperHero
            {
                Name = hero.Name,
                FirstName = hero.FirstName,
                LastName = hero.LastName,
                Place = hero.Place
            };

            try
            {
                await _dataContext.SuperHeroes.AddAsync(newHero);
                await _dataContext.SaveChangesAsync();
                return Ok(newHero);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
