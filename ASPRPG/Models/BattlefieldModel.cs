using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPRPG.Models

{
    public class BattlefieldModel : PageModel
    {
        public Character? Character { get; set; }
        public Enemy? Enemy { get; set; }

        public List<Character> Characters { get; set; }
        public List<Enemy> Enemies { get; set; }
        public void OnGet()
        {
        }
    }
}
