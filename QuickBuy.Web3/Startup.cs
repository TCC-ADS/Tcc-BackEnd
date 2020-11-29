using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Repositorio.Contexto;
using QuickBuy.Repositorio.Repositorios;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace QuickBuy.Web
{
    public class Startup 
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder(); 
            builder.AddJsonFile("config.json", optional : false, reloadOnChange : true);

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Tcc", Version = "v1" });
            });


            var connectionString = Configuration.GetConnectionString("QuickBuyDB");
            var migrationsAssembly = typeof(QuickBuyContexto).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<QuickBuyContexto>(option =>
                                                        option.UseLazyLoadingProxies()
                                                        .UseMySql(connectionString,
                                                                            m => m.MigrationsAssembly(migrationsAssembly)));

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();            
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint( $"/swagger/v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.List);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}");
            });
        }
    }
}
