using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorlds.Web.Models
{
    public class Term
    {
        public Guid Id { get; set; }
        public String OriginalText { get; set; }
        public String EnglishText { get; set; }
        public String Language { get; set; }
        public String ProgrammingLanguage { get; set; }
    }
}