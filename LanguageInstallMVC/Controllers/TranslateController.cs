using LanguageInstall.Data.Data;
using LanguageInstall.Data.DTOs;
using LanguageInstall.Data.Model;
using LanguageInstall.Service.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LanguageInstallMVC.Controllers
{
    public class TranslateController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ITranslationService _translationService;

        public TranslateController(AppDbContext dbContext, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _translationService = translationService;
        }



        // Index View
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.MainTables
                .Include(mt => mt.Translations)
                .Select(mt => new MainTableDto
                {
                    ID = mt.ID,
                    EnglishText = mt.EnglishText,
                    Translations = mt.Translations.ToDictionary(t => t.LanguageCode, t => t.TranslatedText)
                })
                .ToListAsync();

            return View(data);
        }

        // Translate View
        public IActionResult Translate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Translate(string text, string targetLanguage)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(targetLanguage))
            {
                ViewBag.Error = "Text and target language are required.";
                return View();
            }

            try
            {
                var translatedText = await _translationService.TranslateTextAsync(text, targetLanguage);
                ViewBag.TranslatedText = translatedText;
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"An error occurred: {ex.Message}";
            }

            return View();
        }

        // Translate All Records


        public IActionResult TranslateAll()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TranslateAll(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
            {
                ViewBag.Error = "Language code is required.";
                return View("Error");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var allRecords = await _dbContext.MainTables
                .Include(mt => mt.Translations)
                .ToListAsync();

            foreach (var record in allRecords)
            {
                if (record.Translations.Any(t => t.LanguageCode == languageCode))
                    continue;

                var translatedText = await _translationService.TranslateTextAsync(record.EnglishText, languageCode);

                var translation = new Translation
                {
                    MainTableID = record.ID,
                    LanguageCode = languageCode,
                    TranslatedText = translatedText
                };
                _dbContext.Translation.Add(translation);
            }

            await _dbContext.SaveChangesAsync();
            stopwatch.Stop();

            ViewBag.ExecutionTime = $"Execution Time: {stopwatch.Elapsed.Minutes} minute(s) {stopwatch.Elapsed.Seconds} second(s)";
            return View("TranslateAllSuccess");
        }

        // Add Language Column
        public async Task<IActionResult> AddLanguageColumn(int id, string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
            {
                return View("Error", "Language code is required.");
            }

            var mainRecord = await _dbContext.MainTables.Include(mt => mt.Translations).FirstOrDefaultAsync(mt => mt.ID == id);

            if (mainRecord == null)
                return View("Error", "Record not found.");

            if (mainRecord.Translations.Any(t => t.LanguageCode == languageCode))
                return View("Error", "Translation already exists for this language.");

            var translatedText = await _translationService.TranslateTextAsync(mainRecord.EnglishText, languageCode);

            var translation = new Translation
            {
                MainTableID = mainRecord.ID,
                LanguageCode = languageCode,
                TranslatedText = translatedText
            };
            _dbContext.Translation.Add(translation);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
