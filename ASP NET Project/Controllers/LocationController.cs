using ASP_NET_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Project.Controllers
{
    public class LocationController : Controller
    {
        private readonly MineralApplicationDbContext _context;

        public LocationController(
            MineralApplicationDbContext context)
        {
            _context = context;
        }

        
    }
}
