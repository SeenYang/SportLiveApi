using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportLiveApi.IoC;
using SportLiveApi.Models.Entities;

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
            services.AddDbContext<SportLiveDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDB")
                // AppSettings.json can hold multiple env config, and put parameter store/secret manager for higher security concern.
                // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            // Swagger
            services.AddSwaggerGen();
            // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            // services.AddSwaggerGen(options => { options.OperationFilter<SwaggerCustomUserIdentifierHeader>(); });


            services.AddControllers();
            // services.AddApiVersioning();
            // services.AddVersionedApiExplorer(
            //     options =>
            //     {
            //         // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            //         // note: the specified format code will format the version as "'v'major[.minor][-status]"
            //         options.GroupNameFormat = "'v'VVV";
            //
            //         // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
            //         // can also be used to control the format of the API version in route templates
            //         options.SubstituteApiVersionInUrl = true;
            //     });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}