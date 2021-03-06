using CognizantChallengeAPI.Clients;
using CognizantChallengeAPI.Logic;
using CognizantChallengeDAL;
using CognizantChallengeDAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CognizantChallengeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string CorsPolicy = "corsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CognizantChallengeAPI", Version = "v1" });
            });

            services.AddDbContext<CognizantChallengeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy, 
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });            

            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IScoresRepository, ScoresRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ISolutionsRepository, SolutionsRepository>();
            services.AddScoped<ICheckSubmissionLogic, CheckSubmissionLogic>();
            services.AddScoped<IJDoodleClient, JDoodleClient>();

            services.AddHttpClient<IJDoodleClient, JDoodleClient>(c => c.BaseAddress = new System.Uri("https://api.jdoodle.com/v1/"));

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CognizantChallengeAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
