using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib.Models.Context
{
    public class WhiteBoardContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsetting.json");
            IConfiguration configuration = configurationBuilder.Build();
            string connection = configuration.GetConnectionString("Connection");

            optionsBuilder.UseSqlServer(connection);
        }
    }
}
