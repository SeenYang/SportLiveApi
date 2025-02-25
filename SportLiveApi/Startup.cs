using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportLiveApi.IoC;
using SportLiveApi.Models;

namespace SportLiveApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // IoC
            services.RegisterServices(Configuration);
            // Swagger
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddDbContext<SportLiveDbContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "InMemoryDB")
                // AppSettings.json can hold multiple env config, and put parameter store/secret manager for higher security concern.
                // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            // allow CORS
            services.AddCors(o => o.AddPolicy("AllowOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors("AllowOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}