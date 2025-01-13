using System.Diagnostics;
using LanguageInstall.Service.Service;
using LanguageInstallMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageInstallMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocalizationService _translationService;

        public HomeController(ILogger<HomeController> logger, ILocalizationService translationService)
        {
            _logger = logger;
            _translationService = translationService;
        }

        public async Task<IActionResult> Index()
        {
            var languageCode = HttpContext.Items["Language"] as string ?? "en";

            ViewBag.FirstNameLabel = await _translationService.GetTranslationAsync("First Name", languageCode);
            ViewBag.LastNameLabel = await _translationService.GetTranslationAsync("Last Name", languageCode);
            ViewBag.SubmitButton = await _translationService.GetTranslationAsync("Submit", languageCode);

            return View();
            
        }

        public async Task<IActionResult> RazorHelper()
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

        public IActionResult ChangeLanguage(string languageCode)
        {
            Response.Cookies.Append("Language", languageCode, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
