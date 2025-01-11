using LanguageInstall.Data.Data;
using LanguageInstall.Data.DTOs;
using LanguageInstall.Data.Model;
using LanguageInstall.Service.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

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
            //const int batchSize = 1;
            //bool hasMoreRows;

            //do
            //{
                //// Fetch 15 rows at a time that don't have a translation for the requested language
                //var batch = await _dbContext.MainTables
                //    .Include(mt => mt.Translations)
                //    .Where(mt => !mt.Translations.Any(t => t.LanguageCode == languageCode))
                //    .Take(batchSize)
                //    .ToListAsync();

                //hasMoreRows = batch.Any();

                //if (!hasMoreRows) break;

                // Extract English texts
                var englishTexts = await _dbContext.MainTables
                    .Include(mt => mt.Translations)
                    .Where(mt => !mt.Translations.Any(t => t.LanguageCode == languageCode)).ToListAsync();

            // Merge texts using a separator
            // Configure Selenium WebDriver
            var options = new ChromeOptions();
               // options.AddArgument("--headless"); // Run browser in headless mode
                options.AddArgument("--disable-gpu");
                options.AddArgument("--no-sandbox");

                using (var driver = new ChromeDriver(options))
                {
                    try
                    {
                        // Open Google Translate
                        string url = $"https://translate.google.com/?hl=en&sl=en&tl={languageCode}&op=translate";
                        driver.Navigate().GoToUrl(url);

                        foreach (var item in englishTexts)
                        {
                            Thread.Sleep(1000);

                            // Locate the input box and enter the text
                            var sourceTextBox = driver.FindElement(By.XPath("//textarea[@aria-label='Source text']"));
                            sourceTextBox.Clear();
                            sourceTextBox.SendKeys(item.EnglishText);

                            // Wait for the translation to complete
                            Thread.Sleep(1000);

                            //// Retrieve the translated text
                            //var outputBox = driver.FindElement(By.XPath("//div[@class='J0lOec']"));
                            //result = outputBox.Text;

                            // Wait for translation with WebDriverWait instead of Thread.Sleep
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                            Thread.Sleep(1000);
                            var translationContainer = wait.Until(d => d.FindElement(By.ClassName("ryNqvb")));
                            var result = translationContainer.Text;

                            var translation = new Translation
                            {
                                MainTableID = item.ID,
                                LanguageCode = languageCode,
                                TranslatedText = result,
                            };

                            _dbContext.Translation.Add(translation);
                            await _dbContext.SaveChangesAsync();
                        }

                        // Wait for the page to load

                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error during translation: {ex.Message}");
                    }
                    finally
                    {
                        driver.Quit();
                    }
                }
                //// Map the translations back to the records and save
                //for (int i = 0; i < batch.Count; i++)
                //{
                //    var record = batch[i];
                //    var translatedText = translatedTexts[i];

                //    // Save the translation
                //    var translation = new Translation
                //    {
                //        MainTableID = record.ID,
                //        LanguageCode = languageCode,
                //        TranslatedText = translatedText
                //    };

                //    _dbContext.Translation.Add(translation);
                //}

                //// Save changes to the database
                //await _dbContext.SaveChangesAsync();

            //} while (hasMoreRows);

            //ViewBag.ExecutionTime = $"Execution Time: {stopwatch.Elapsed.Minutes} minute(s) {stopwatch.Elapsed.Seconds} second(s)";
            return RedirectToAction("Index", "Translations");

        }

        //[HttpPost]
        //public async Task<IActionResult> TranslateAll(string languageCode)
        //{
        //    const int batchSize = 1;
        //    bool hasMoreRows;

        //    do
        //    {
        //        // Fetch 15 rows at a time that don't have a translation for the requested language
        //        var batch = await _dbContext.MainTables
        //            .Include(mt => mt.Translations)
        //            .Where(mt => !mt.Translations.Any(t => t.LanguageCode == languageCode))
        //            .Take(batchSize)
        //            .ToListAsync();

        //        hasMoreRows = batch.Any();

        //        if (!hasMoreRows) break;

        //        // Extract English texts
        //        var englishTexts = batch.Select(record => record.EnglishText).ToList();

        //        // Merge texts using a separator
        //        var mergedText = string.Join(", ", englishTexts); // Use "||" as a unique separator

        //        // Translate the batch
        //        var translatedTex = await _translationService.PerformTranslation(mergedText, languageCode);

        //        var translatedTexts = translatedTex.Split(", ").ToList();

        //        // Map the translations back to the records and save
        //        for (int i = 0; i < batch.Count; i++)
        //        {
        //            var record = batch[i];
        //            var translatedText = translatedTexts[i];

        //            // Save the translation
        //            var translation = new Translation
        //            {
        //                MainTableID = record.ID,
        //                LanguageCode = languageCode,
        //                TranslatedText = translatedText
        //            };

        //            _dbContext.Translation.Add(translation);
        //        }

        //        // Save changes to the database
        //        await _dbContext.SaveChangesAsync();

        //    } while (hasMoreRows);

        //    //ViewBag.ExecutionTime = $"Execution Time: {stopwatch.Elapsed.Minutes} minute(s) {stopwatch.Elapsed.Seconds} second(s)";
        //    return RedirectToAction("Index", "Translations");

        //}

        //[HttpPost]
        //public async Task<IActionResult> TranslateAll(string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //    {
        //        ViewBag.Error = "Language code is required.";
        //        return View("Error");
        //    }

        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();

        //    var allRecords = await _dbContext.MainTables
        //        .Include(mt => mt.Translations)
        //        .ToListAsync();

        //    foreach (var record in allRecords)
        //    {
        //        if (record.Translations.Any(t => t.LanguageCode == languageCode))
        //            continue;

        //        var translatedText = await _translationService.TranslateTextAsync(record.EnglishText, languageCode);

        //        var translation = new Translation
        //        {
        //            MainTableID = record.ID,
        //            LanguageCode = languageCode,
        //            TranslatedText = translatedText
        //        };
        //        _dbContext.Translation.Add(translation);
        //    }

        //    await _dbContext.SaveChangesAsync();
        //    stopwatch.Stop();

        //    ViewBag.ExecutionTime = $"Execution Time: {stopwatch.Elapsed.Minutes} minute(s) {stopwatch.Elapsed.Seconds} second(s)";
        //    return View("TranslateAllSuccess");
        //}

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
