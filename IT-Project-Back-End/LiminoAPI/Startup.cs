using System;
using LiminoAPI.Business.Services;
using LiminoAPI.Data;
using LiminoAPI.Data.Models;
using LiminoAPI.Data.Repositories;
using LiminoAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace LiminoAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add DBContext to services
            services.AddDbContext<AppDbContext>(options =>
            {
//                options.UseMySql(
//                    Configuration.GetConnectionString("DefaultConnection"),
//                    mysqloptions =>
//                    {
//                        mysqloptions.MigrationsAssembly("LiminoAPI");
//                        mysqloptions.ServerVersion(Version.Parse("10.3"), ServerType.MariaDb);
//                    }
//                );
                options.UseSqlServer(
//                    Configuration.GetConnectionString("azure_connection"),
                        "Server=liminodb.database.windows.net;Database=LiminoDB;User ID=limino;Password=Paswoord123;Trusted_Connection=False;MultipleActiveResultSets=true",
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                        sqlOptions.MigrationsAssembly("LiminoAPI");
                    }
                );

                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            });

            // TODO: Add Repositories to services
            services.AddTransient<IBaseRepository<Video>, BaseRepository<Video>>();
            services.AddTransient<IVideoService, VideoService>();

            services.AddTransient<IBaseRepository<Exercise>, ExerciseRepository>();
            services.AddTransient<IExerciseService, ExerciseService>();
            
            services.AddTransient<IExerciseSeriesRepository, ExerciseSeriesRepository>();
            services.AddTransient<IExerciseSeriesService, ExerciseSeriesService>();

            services.AddTransient<IAudioService, AudioService>();
            services.AddTransient<IBaseRepository<Audio>, BaseRepository<Audio>>();

            services.AddTransient<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
            services.AddTransient<IUserService, UserService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                // Don't let EF endlessly walk ManyToMany relationships
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // Return human readable json for easy debugging
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            // Easy cors policy, should be well defined at the end of the project.
            services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
           });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.Use( (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "*");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                context.Response.Headers.Add("Access-Control-Expose-Headers", "*");
                context.Response.Headers.Add("Access-Control-Max-Age", "*");
                context.Response.Headers.Add("Access-Control-Request-Headers", "*");
                context.Response.Headers.Add("Access-Control-Request-Method", "*");
                context.Response.Headers.Add("Origin", "*");
                
                if (context.Request.Method == "OPTIONS")
                {
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync("");
                }
                
                return next();
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
