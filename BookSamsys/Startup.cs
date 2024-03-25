using Microsoft.EntityFrameworkCore;
using BookSamsys.Controllers;
using BookSamsys.Infrastructures.Models;
using BookSamsys.Infrastructures.Repository;
using BookSamsys.Infrastructures.Services;
using Newtonsoft.Json;
using System.Text.Json;
using BookSamsys.Infrastructures.Mappers;
using AutoMapper;

namespace BookSamsys
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<BookRepository>();
            services.AddScoped<BookService>();
  
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Configuração do Entity Framework Core (substitua com sua configuração)
            services.AddDbContext<BookAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000") // Substitua pelo URL do seu aplicativo React
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("AllowSpecificOrigins");
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
