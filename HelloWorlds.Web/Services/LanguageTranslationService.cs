using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorlds.Web.Services
{
    public class LanguageTranslationService
    {
        Dictionary<string, string> languageTerms;
        public LanguageTranslationService()
        {
            languageTerms = new Dictionary<string, string>()
            {
                { "طالب", "Student" },
                { "حساب", "Calculate"},
                { "س", "s"},
                { "المدرسة", "School" }
            };
        }

        public String Translate(string word)
        {
            languageTerms.TryGetValue(word, out string translatedWord);
            return translatedWord;
        }
    }
}