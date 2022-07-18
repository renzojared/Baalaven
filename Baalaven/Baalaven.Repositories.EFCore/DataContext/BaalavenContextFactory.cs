using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.Repositories.EFCore.DataContext
{
    class BaalavenContextFactory : IDesignTimeDbContextFactory<BaalavenContext>
    {
        public BaalavenContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<BaalavenContext>();
            //OptionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=BaalavenDB"); //mssqllocaldb: connection name

            OptionBuilder.UseSqlServer("Server = localhost; Database = BaalavenDB; User Id = sa; Password = docker@TPA09"); // for docker container
            
            return new BaalavenContext(OptionBuilder.Options);
            //add-migration InitialCreate -p Baalaven.Repositories.EFCore -c BaalavenContext -o Migrations -s Baalaven.Repositories.EFCore
            // -p : Default project // -c : Context data // -o : place folder // -s : initial project or tools to start
            //update-database -p Baalaven.Repositories.EFCore -s Baalaven.Repositories.EFCore
            //remove - migration - p Baalaven.Repositories.EFCore - s Baalaven.Repositories.EFCore
            /*
             See errors:
                https://localhost:{PortNo}/swagger/v1/swagger.json
                https://stackoverflow.com/questions/56859604/swagger-not-loading-failed-to-load-api-definition-fetch-error-undefined
             */
        }
    }
}
