using ASPRPG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPRPG.Views
{
    public class BattleViewModel : PageModel
    {
        public Character Character { get; set; }
        public Enemy Enemy { get; set; }
        public void OnGet()
        {
        }
    }
}
