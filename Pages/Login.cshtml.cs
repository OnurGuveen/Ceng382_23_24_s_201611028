using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Pages
{
    public class UserLoginModel : PageModel
    {
        private readonly HotelReservationContext _dbContext;

        public UserLoginModel(HotelReservationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string UserEmail { get; set; }

        [BindProperty]
        public string UserPassword { get; set; }

        public void OnLoad()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _dbContext.Users
                .Where(u => u.Email == UserEmail && u.Password == UserPassword)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                return Page();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToPage("/HomePage");
        }
    }
}
