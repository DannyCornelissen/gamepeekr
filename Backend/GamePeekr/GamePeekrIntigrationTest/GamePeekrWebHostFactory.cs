using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GamePeekrIntigrationTest
{
    internal class GamePeekrWebHostFactory: WebApplicationFactory<Program>
    {
        private const string environment = "Testing";
         protected override void ConfigureWebHost(IWebHostBuilder builder)
         {
             builder.UseEnvironment(environment);
             builder.UseUrls("http://localhost:3200");
         }
    }
}
