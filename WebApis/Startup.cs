using System;
using DataAccessor;
using Dominios;
using Dominios.Interfaces;
using Managers;
using Managers.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Modelos;
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

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options => {
					options.TokenValidationParameters = new TokenValidationParameters {
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["JwtConfig:Issuer"],
						ValidAudience = Configuration["JwtConfig:Audience"],

						IssuerSigningKey = new SymmetricSecurityKey(
							Convert.FromBase64String(Configuration["JwtConfig:SecretKey"])
						)
					};

				});

			

			//WebApis
			services.AddScoped<IManagerUsuarios, cManagerUsuarios>(); 
			services.AddScoped<IManagerCategorias, cManagerCategorias>();
			services.AddScoped<IManagerImagenes, cManagerImagenes>();
			services.AddScoped<IManagerMemeGen, cManagerMemeGen>();

			//Managers
			JwtConfigModelo lJwtCfg = new JwtConfigModelo();
			Configuration.GetSection("JwtConfig").Bind(lJwtCfg);
			services.AddSingleton<JwtConfigModelo>(lJwtCfg);

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
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
