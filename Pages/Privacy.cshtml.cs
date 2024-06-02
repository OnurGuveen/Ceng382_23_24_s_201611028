using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Reservation.Pages
{
    public class ConfidentialityModel : PageModel
    {
        private readonly ILogger<ConfidentialityModel> _logger;

        public ConfidentialityModel(ILogger<ConfidentialityModel> logger)
        {
            _logger = logger;
        }

        public void OnLoad()
        {
        }
    }
}
