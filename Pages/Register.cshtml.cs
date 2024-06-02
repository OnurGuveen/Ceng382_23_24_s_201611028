using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Pages
{
    public class UserRegisterModel : PageModel
    {
        private readonly HotelReservationContext _dbContext;

        public UserRegisterModel(HotelReservationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public User NewUser { get; set; }

        public void OnLoad()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Users.Add(NewUser);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Login");
        }
    }
}
