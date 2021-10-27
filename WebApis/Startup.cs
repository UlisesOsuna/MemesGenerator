using DataAccessor;
using Dominios;
using Dominios.Interfaces;
using Managers;
using Managers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorios;
using Repositorios.Interfaces;

namespace WebApis {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration {
			get;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();

			//WebApis
			services.AddScoped<IManagerUsuarios, cManagerUsuarios>(); 
			services.AddScoped<IManagerCategorias, cManagerCategorias>();
			services.AddScoped<IManagerImagenes, cManagerImagenes>();
			services.AddScoped<IManagerMemeGen, cManagerMemeGen>();

			//Managers
			services.AddScoped<IDominioUsuarios, cDominioUsuarios>();
			services.AddScoped<IDominioCategorias, cDominioCategorias>();
			services.AddScoped<IDominioImagenes, cDominioImagenes>();

			//Dominios
			services.AddScoped<IRepositorioUsuarios, cRepositorioUsuarios>();
			services.AddScoped<IRepositorioCategorias, cRepositorioCategorias>();
			services.AddScoped<IRepositorioImagenes, cRepositorioImagenes>();

			services.AddDbContext<cStoreDataDbContext>(x => {
				x.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app
			, IWebHostEnvironment env) {

			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
