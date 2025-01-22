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
        private readonly ITranslateOperation _translateOperation;

        public LocalizationService(AppDbContext context, ITranslateOperation translateOperation)
        {
            _context = context;
            _translateOperation = translateOperation;
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

        private async Task TranslateOperratipnm(string key, IQueryable<string> distinctTranslationCodes, int id)
        {
            var res = await _translateOperation.OperationMultiLanguage(key, distinctTranslationCodes, id);

            while (true)
            {
                var invalidTranslations = _context.Translation
                    .Where(t => res.Contains(t.ID) && (string.IsNullOrEmpty(t.TranslatedText) || t.TranslatedText.Contains("%??") || t.TranslatedText.Contains("??%") || t.TranslatedText.Contains("%??%") ))
                    .Include(t => t.MainTable)
                    .ToList();

                if (!invalidTranslations.Any())
                    break;

                foreach (var translation in invalidTranslations)
                {
                    try
                    {
                        SaveNotification(translation);
                        await _translateOperation.OperationSINGLELanguageUpdate(
                            translation.MainTable.EnglishText,
                            translation.LanguageCode,
                            translation.MainTableID,
                            translation.ID
                        );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error translating: {ex.Message}");
                    }
                }
            }
        }

        private void SaveNotification(Translation translation)
        {
            Notification notification = new Notification()
            {
                RecordTime = DateTime.Now,
                MainTableId = translation.MainTableID,
                TranslateTableId = translation.ID,
                EnglishText = translation.MainTable.EnglishText,
                LangCode = translation.LanguageCode,
                TranslateText = translation.TranslatedText,
                Remark = "unChecked"
            };
            _context.Add(notification);
            _context.SaveChangesAsync();
        }
    }

}
