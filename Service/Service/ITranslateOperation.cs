using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageInstall.Data.Model;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using LanguageInstall.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace LanguageInstall.Service.Service
{
    public interface ITranslateOperation
    {
        Task<List<int>> OperationMultiLanguage(string key, IQueryable<string> distinctTranslationCodes, int id);
        Task<int> OperationSINGLELanguageUpdate(string key, string distinctTranslationCodes, int id, int Pkey);
    }

    public class TranslateOperation : ITranslateOperation
    {
        private readonly AppDbContext _context;

        public TranslateOperation(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<int>> OperationMultiLanguage(string key, IQueryable<string> distinctTranslationCodes, int id)
        {
            int sleepTime = 1000;

            List<int> translationCodes = new List<int>();


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

                        translationCodes.Add(translation.ID);
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

            return translationCodes;

        }

        public async Task<int> OperationSINGLELanguageUpdate(string key, string distinctTranslationCodes, int id, int Pkey)
        {
            int sleepTime = 1000;

            int a;


            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    //var langugeCode = distinctTranslationCodes.ToString();

                    //var a = translateWebOperation(key, langugeCode);
                   
                        string url = $"https://translate.google.com/?hl=en&sl=en&tl={distinctTranslationCodes}&op=translate";
                        driver.Navigate().GoToUrl(url);

                        Thread.Sleep(sleepTime);

                        var sourceTextBox = driver.FindElement(By.XPath("//textarea[@aria-label='Source text']"));

                        sourceTextBox.Clear();
                        sourceTextBox.SendKeys(key);
                        Thread.Sleep(2000);

                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        var translationContainer = wait.Until(d => d.FindElement(By.ClassName("usGWQd")));
                        var result = translationContainer.Text;



                    // Fetch the existing Translation entity from the database
                    var existingTranslation = await _context.Translation.FirstOrDefaultAsync(t => t.ID == Pkey);

                    if (existingTranslation != null)
                    {
                        // Update the existing entity's properties
                        existingTranslation.MainTableID = id;
                        existingTranslation.LanguageCode = distinctTranslationCodes;
                        existingTranslation.TranslatedText = result;

                        // Mark the entity as modified
                        _context.Update(existingTranslation);
                    }
                    else
                    {
                        // If the entity doesn't exist, create a new one
                        var translation = new Translation
                        {
                            ID = Pkey,
                            MainTableID = id,
                            LanguageCode = distinctTranslationCodes,
                            TranslatedText = result
                        };

                        // Add the new entity to the context
                        _context.Add(translation);
                    }

                    // Save changes to the database
                    await _context.SaveChangesAsync();



                    //var existingTranslation = await _context.Translation.FirstOrDefaultAsync(t => t.ID == Pkey);

                    //if (existingTranslation != null)
                    //{
                    //    existingTranslation.MainTableID = id;
                    //    existingTranslation.LanguageCode = distinctTranslationCodes; 
                    //    existingTranslation.TranslatedText = result;

                    //    await _context.SaveChangesAsync();

                    //}



                    //var translation = new Translation
                    //{
                    //    ID = Pkey,
                    //    MainTableID = id,
                    //    LanguageCode = distinctTranslationCodes,
                    //    TranslatedText = result,

                    //};

                    //_context.Update(translation);

                    //await _context.SaveChangesAsync();








                }
                catch (Exception ex)
                {
                    throw new Exception($"Error during translation: {ex.Message}");
                }
                finally
                {
                    driver.Quit();
                }

                return Pkey;
            }

           
        }

       
    }
}
