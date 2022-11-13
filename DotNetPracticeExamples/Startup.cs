using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DotNetPracticeExamples.Data;
using DotNetPracticeExamples.Repository.IRepository;
using DotNetPracticeExamples.Repository;
using DotNetPracticeExamples.Services;
using DotNetPracticeExamples.Services.IService;

namespace DotNetPracticeExamples
{
	/// ///////////////////////////////// Startup: configures the entity framework /////////////////////////////////

	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{ Configuration = configuration; }

		/// /////////// This method gets called by the runtime. Use this method to add services to the container ///////////
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			//Add header availability for XML response type (JSON is the default)
			services.AddMvc().AddXmlSerializerFormatters();

			//Add 'Swagger generator' to 'services' container at runtime
			services.AddSwaggerGen(c =>
			{
				//Define document to be created by Swagger generator
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetPracticeExamples", Version = "v1" });
			});

			//'.AddDbContext' (.NET extension of 'EntityFrameworkServiceCollectionExtensions' class) -- Registers the context class as a service
			//- 'ApiDbContext' is registered as a service
			//- '.UseSqlServer' (.NET extension of 'SqlServerDbContextOptionsExtensions' class) -- Configures the context to connect to a Microsoft SQL Server database
			services.AddDbContext<ApiDbContext>(option => option.UseSqlServer(@"Data Source=GUNNANMON\SQLEXPRESS; Initial Catalog=DotNetPracticeExamples; Integrated Security=True; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;"));

			//Dependancy injection
			services.AddScoped<IAlbumRepository, AlbumRepository>();
			services.AddScoped<IAlbumService, AlbumService>();
			services.AddScoped<IGenreRepository, GenreRepository>();
			services.AddScoped<IGenreService, GenreService>();
			services.AddScoped<IDistributorRepository, DistributorRepository>();
			services.AddScoped<IDistributorService, DistributorService>();

		}

		/// /////////// This method gets called by the runtime. Use this method to configure the HTTP request pipeline ///////////

		//
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				//Configure Swagger at runtime
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetPracticeExamples v1"));
			}

			/*
			////// need to add to 'Configure()' the parameter "ApiDbContext dbContext" for below //////
			//'Database' (.NET extension of 'DbContext' class) -- Provides access to database related information and operations for this context
			//- '.EnsureCreated' (.NET extension of 'DatabaseFacade' class) -- Checks if database for context exists and creates it if it does not based on the context
			//- '.EnsureCreated' will not update the existing database on changes
			dbContext.Database.EnsureCreated();
			*/

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
