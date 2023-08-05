using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoardProject.Class;

namespace WhiteboardLibs.Class.DatabaseContext
{
    public class WhiteboardDb : DbContext
    {
       public DbSet<CanvasColor> canvasColors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsetting.json");
        }
    }
}
