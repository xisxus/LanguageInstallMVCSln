using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInstall.Data.Data;
using LanguageInstall.Data.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace LanguageInstall.Service.Service
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key, string languageCode);
        Task<string> GetTranslationAsync(string key, string languageCode);
        Task<List<string>> GetLang();
    }

    public class LocalizationService : ILocalizationService
    {
        private readonly AppDbContext _context;

        public LocalizationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetLang()
        {
            // Fetch distinct language codes from the Translation table
            var languageCodes = await _context.Translation
                .Select(t => t.LanguageCode)
                .Distinct()
                .ToListAsync();

            // Add "en" at the beginning if it's not already in the list
            if (!languageCodes.Contains("en"))
            {
                languageCodes.Insert(0, "en");
            }


            return languageCodes;
        }
        public string GetLocalizedString(string key, string languageCode)
        {
            var mainEntry = _context.MainTables
                .Include(m => m.Translations)
                .FirstOrDefault(m => m.EnglishText == key);

            if (mainEntry == null)
            {
                return key; // Return the key as fallback if no entry is found
            }

            var translation = mainEntry.Translations
                .FirstOrDefault(t => t.LanguageCode == languageCode);

            return translation?.TranslatedText ?? mainEntry.EnglishText; // Return translation or fallback to English
        }
        public async Task<string> GetTranslationAsync(string key, string languageCode)
        {
            var mainEntry = await _context.MainTables
                .Include(m => m.Translations)
                .FirstOrDefaultAsync(m => m.EnglishText == key);

            if (mainEntry == null)
            {
                var Id =  await SaveToDatabase(key);
                await InstallLocal(key, Id);
                
               // return key;
            } 

            var translation = mainEntry?.Translations.FirstOrDefault(t => t.LanguageCode == languageCode);

            

            return translation?.TranslatedText ?? key; // Fallback to English text
        }

       

        private async Task< int> SaveToDatabase(string key)
        {
            MainTable mainTable = new MainTable()
            {
                EnglishText = key
            };
            _context.Add(mainTable);
            await _context.SaveChangesAsync();
            return mainTable.ID;
        }


        private async Task<bool> InstallLocal(string key , int id)
        {
            var distinctTranslationCodes =  _context.Translation
               .Select(trans => trans.LanguageCode)
               .Distinct();

            if (distinctTranslationCodes.Any())
            {
                await TranslateOperratipnm(key, distinctTranslationCodes , id);
            }
            return true;
        }

        private async Task TranslateOperratipnm(string key, IQueryable<string> distinctTranslationCodes , int id)
        {
            
            int sleepTime = 1000;
         

           

            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    foreach (var item in distinctTranslationCodes)
                    {
                        string url = $"https://translate.google.com/?hl=en&sl=en&tl={item}&op=translate";
                        driver.Navigate().GoToUrl(url);

                        Thread.Sleep(sleepTime);

                        var sourceTextBox = driver.FindElement(By.XPath("//textarea[@aria-label='Source text']"));

                        sourceTextBox.Clear();
                        sourceTextBox.SendKeys(key);
                        Thread.Sleep(2000);

                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        var translationContainer = wait.Until(d => d.FindElement(By.ClassName("usGWQd")));
                        var result = translationContainer.Text;

                        var translation = new Translation
                        {
                            MainTableID = id,
                            LanguageCode = item,
                            TranslatedText = result,

                        };

                        _context.Translation.Add(translation);
                        await _context.SaveChangesAsync();

                    }
                    

                   

                   
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

           
        }
    }

}
