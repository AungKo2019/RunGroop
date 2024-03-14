using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;

namespace RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRaceRepository _raceRepository;
        public RaceController(ApplicationDbContext context, IRaceRepository raceRepository)
        {
            _context = context;
            _raceRepository = raceRepository;
        }
        //public IActionResult Index()
        //{
        //    List<Race> races = _context.Races.ToList();
        //    return View(races);
        //}
        //public IActionResult Detail(int id)
        //{
        //    Race race = _context.Races.Include(a => a.Address).FirstOrDefault(r => r.Id == id);
        //    return View(race);
        //}

        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }
    }
}
