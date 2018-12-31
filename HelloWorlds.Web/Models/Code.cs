using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorlds.Web.Models
{
    public class Code
    {
        public Guid Id { get; set; }
        public String FileName { get; set; }

        [DataType(DataType.MultilineText)]
        public String OriginalSource { get; set; }

        [DataType(DataType.MultilineText)]
        public String SourceCode { get; set; }
        public String Language { get; set; }
        public String ProgrammingLanguage { get; set; }
        public DateTime Date { get; set; }
        public String User { get; set; }
        public Visibility Visibility { get; set; }
    }

    public enum Visibility
    {
        Public,
        Private,
        InviteOnly
    }
}