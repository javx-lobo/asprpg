using ASPRPG.Models;
using ASPRPG.Views;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASPRPG.Controllers
{
    [Route("Battle/Battle")]
    public class BattleController : Controller
    {
        private readonly YourDbContext _context;

        public BattleController(YourDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Battlefield() 
        {
            var characters = GetRandomCharacters();
            var enemies = GetRandomEnemies();

            var model = new BattlefieldModel
            {
                Characters = characters,
                Enemies = enemies
            };

            return View(model);
        }

        private List<Character> GetRandomCharacters()
        {
            int flaggers = 0;
            var characters = new List<Character>();
            while (flaggers != 3) 
            {
            var random = new Random();
            var characterCount = _context.Character.Count();
            var randomIndexes = Enumerable.Range(0, characterCount)
                .OrderBy(x => random.Next())
                .Take(characterCount)
                .Take(3)
                .ToList();
       
            characters = _context.Character
                .Where(e => randomIndexes.Any(i => i == e.Id))
                .ToList();

            flaggers = characters.Count;
            }
            
            return characters;
        }

        private List<Enemy> GetRandomEnemies()
        {
            var random = new Random();
            var enemyCount = _context.Enemy.Count();
            var randomIndexes = Enumerable.Range (0, enemyCount)
                .OrderBy(x => random.Next())
                .Take(random.Next(1, 8))
                .ToList();
            var enemies = _context.Enemy
                .Where(e => randomIndexes.Any(i => i == e.Id))
                .ToList();
            return enemies;
        }

        [HttpPost]
        [Route("Attack")]
        public IActionResult Attack(string characterName, string enemyName)
        {
            Character character = _context.Character.Where(c => c.Name == characterName).FirstOrDefault();
            Enemy enemy = _context.Enemy.Where(e => e.Name == enemyName).FirstOrDefault();

            character.AttackEnemy(enemy);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetEnemies")]
        public IActionResult GetEnemies()
        {
            using (var context = _context) 
            { 
              List<Enemy> enemies= context.Enemy.ToList();  
                return Ok(enemies);
            }
            
            
        }
    }
}
