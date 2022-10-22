using DotNetPracticeExamples;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPracticeExamples
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args) //Call method below to build the host
			.Build()                //Initialize the host and return an 'IHost' which sets the configuration
			.Run();                 //Run the method with 'IHost' configuration
		}

		//'CreateHostBuilder()' Static method returns an 'IHostBuilder' interface
		//- 'IHostBuilder' is a .NET program initialization extension
		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)                  //'.CreateDefaultBuilder' (.NET extension of the 'Host' class) -- returns pre-configured defaults as an 'IHostBuilder'
				   .ConfigureWebHostDefaults(webBuilder =>          //'.ConfigureWebHostDefaults' (.NET extension of the 'GenericHostBuilderExtensions' class) -- configures the 'IHostBuilder'
						   { webBuilder.UseStartup<Startup>(); }    //'.UseStartup'  (.NET extension of 'WebHostBuilderExtensions' class) -- specifies the web host startup class containing application functionality
				   );
		}

	}
}
