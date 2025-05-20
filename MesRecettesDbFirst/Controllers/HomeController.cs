using System.Diagnostics;
using MesRecettesDbFirst.Data;
using MesRecettesDbFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MesRecettesDbFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MeRecettesDbFirstDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MeRecettesDbFirstDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Recettes()
        {
            var recettes = await _dbContext.Recettes
                .Include(r => r.TypeAliment)
                .Include(r => r.OrigineAliment)
                .Include(r => r.Ingredients)
                .ToListAsync();
            return View(recettes);
        }
    }
}
