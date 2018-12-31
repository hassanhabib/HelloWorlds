using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HelloWorlds.Web.Models
{
    public class Storage : DbContext
    {
        public DbSet<Code> Codes { get; set; }
        public DbSet<Term> Terms { get; set; }
    }
}