using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IClubRepository _clubRepository;
        public ClubController(ApplicationDbContext context,IClubRepository clubRepository )
        {
            _context=context;
            _clubRepository=clubRepository;
        }
        //public IActionResult Index()
        //{
        //    List<Club> clubs = _context.Clubs.ToList();
        //    return View(clubs);
        //}

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        //public IActionResult Detail(int id)
        //{
        //    Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(x => x.Id == id);
        //    return View(club);
        //}

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if(!ModelState.IsValid) 
            {
                return View(club);
            }
             _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
    }
}
