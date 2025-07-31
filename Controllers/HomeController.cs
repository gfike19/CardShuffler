using CardShuffler.Models;
using CardShuffler.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace CardShuffler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Deck d = new Deck();
            d.Shuffle();
            var model = new IndexViewModel
            {
                deck = d
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model, string action)
        {
            if (action == "drawOne")
                return RedirectToAction("DrawOne", new { data = model.deck });
            else if (action == "drawAll")
                return RedirectToAction("DrawAll", new { data = model.deck });

            return View();
        }

        [HttpGet]
        public IActionResult DrawOne(Deck deck)
        {
            Card c = deck.Draw();
            return View(c);
        }

        [HttpGet]
        public IActionResult DrawAll(Deck deck)
        {
            List<Card> cards = deck.getAllCards();
            return View(cards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
