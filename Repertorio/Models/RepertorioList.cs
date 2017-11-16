using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Repertorio.Models
{
    public class RepertorioList
    {
        public int ID { get; set; }
        public string DsFaixa { get; set; }
        public string DsArtista { get; set; }
        public int CdDificuldade { get; set; }
    }

    public class RepertorioDBContext : DbContext
      {
          public DbSet<RepertorioList> RepertoriosList { get; set; }
    }   
}