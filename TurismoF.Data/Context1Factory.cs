using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoF.Data.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TurismoF.Data
{
    public class Context1Factory:IDesignTimeDbContextFactory<Context1>
    {
        public Context1 CreateDbContext(string[] args)
        {
            // Ajusta el nombre del folder si tu proyecto API tiene otro nombre
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "TurismoF.API");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<Context1>();
            var connectionString = configuration.GetConnectionString("Context");
            builder.UseNpgsql(connectionString);

            return new Context1(builder.Options);
        }
    }
}
