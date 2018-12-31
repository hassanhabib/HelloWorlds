using HelloWorlds.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorlds.Web.Services
{
    public class CodeTranslationService
    {
        Storage storage = new Storage();

        public String GetNativeSourceCode(Code code)
        {
            List<Char> contents = code.OriginalSource.ToCharArray().ToList();
            List<string> terms = new List<string>();
            string word = "";
            string nativeCode = "";

            foreach (char content in contents)
            {
                if (content == '؛' 
                    || content == ' ' 
                    || content == '\r' 
                    || content == '\n' 
                    || content == ')' 
                    || content == '('
                    || content == '{'
                    || content == '}')
                {
                    if (word.Length > 0)
                    {
                        terms.Add(word);
                        word = "";
                    }
                    terms.Add(content.ToString());
                }
                else
                {
                    word += content;
                }
            }

            foreach (var term in terms)
            {
                if (term == ' '.ToString() 
                    || term == "\r" 
                    || term == "\n" 
                    || term == ")" 
                    || term == "("
                    || term == "}"
                    || term == "{")
                {
                    nativeCode += term;
                }
                else
                {
                    string nativeTerm = GetTerm(term, code.Language, code.ProgrammingLanguage);
                    nativeCode += nativeTerm;

                }
            }

            return nativeCode;
        }

        public String GetTerm(string term, string language, string programmingLanguage)
        {
            LanguageTranslationService languageTranslationService = new LanguageTranslationService();

            if (languageTranslationService.Translate(term) != null)
            {
                return languageTranslationService.Translate(term);
            }
            else
            {
                return storage
                    .Terms
                    .Single(trm =>
                        trm.OriginalText == term
                        && trm.ProgrammingLanguage == programmingLanguage
                        && trm.Language == language)
                    .EnglishText;
            }
        }
    }
}