using AIIntegration.Models;
using GroqSharp;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AIIntegration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGroqClient _groqClient;

        public HomeController(ILogger<HomeController> logger , IGroqClient groqClient)
        {
            _logger = logger;
            _groqClient = groqClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string question)
        {
            // If want to put with the question any thing to controll the answer or add or delete what i want by concat the question by what i want 
            // question = string.Concat(question , "Please answer in 50 characters or less with a Camath Palihapitiya imprsnation.")

            string answer = await _groqClient.CreateChatCompletionAsync(new GroqSharp.Models.Message { Content = question});

            ViewBag.Answer = answer;

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
    }
}
