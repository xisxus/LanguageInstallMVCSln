using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInstall.Data.Data;
using LanguageInstall.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
                MainTable mainTable = new MainTable()
                {
                    EnglishText = key
                };
                _context.Add(mainTable);
               await _context.SaveChangesAsync();
                return key;
            } 

            var translation = mainEntry.Translations.FirstOrDefault(t => t.LanguageCode == languageCode);

            

            return translation?.TranslatedText ?? key; // Fallback to English text
        }
    }

}
