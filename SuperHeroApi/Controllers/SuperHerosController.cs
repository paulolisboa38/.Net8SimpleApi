using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHerosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<SuperHero>> GetAllHeroes()
        {
            var heroes = new List<SuperHero>
            {
                new() {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };
            return Ok(heroes);
        }
    }
}
