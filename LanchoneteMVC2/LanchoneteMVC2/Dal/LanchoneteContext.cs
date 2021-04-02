using LanchoneteMVC2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LanchoneteMVC2.Dal
{
    public class LanchoneteContext : DbContext
    {
        public LanchoneteContext() : base("LanchoneteContext")
        {
        }
        public DbSet<Refeicao> Refeicoes { set; get; }
       
    }
}