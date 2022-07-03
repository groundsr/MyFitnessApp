using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyFitnessApp.BLL;
using MyFitnessApp.DAL;
using MyFitnessApp.DAL.Abstractions;
using MyFitnessApp.Data;
using MyFitnessApp.Helpers;

namespace MyFitnessApp
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

            services.AddControllers();
            services.AddDbContext<FitnessContext>(options =>
            options.UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});

            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<EFUserRepository>();
            services.AddScoped<IUserPlanRepository, EFUserPlanRepository>();
            services.AddScoped<UserPlanService>();
            services.AddScoped<IUserGoalRepository, EFUserGoalRepository>();
            services.AddScoped<UserGoalService>();
            services.AddScoped<IDiaryRepository, EFDiaryRepository>();
            services.AddScoped<DiaryService>();
            services.AddScoped<IMealRepository, EFMealRepository>();
            services.AddScoped<EFMealRepository>();
            services.AddScoped<IBreakfastMealRepository, EFBreakfastMealRepository>();
            services.AddScoped<ILunchMealRepository, EFLunchMealRepository>();
            services.AddScoped<IDinnerMealRepository, EFDinnerMealRepository>();
            services.AddScoped<MealService>();
            services.AddScoped<IExerciseRepository, EFExerciseRepository>();
            services.AddScoped<ExerciseService>();
            services.AddScoped<IUserProgressRepository, EfUserProgressRepository>();
            services.AddScoped<UserProgressService>();
            services.AddScoped<IBreakfastRepository, EFBreakfastRepository>();
            services.AddScoped<ILunchRepository, EFLunchRepository>();
            services.AddScoped<IDinnerRepository, EFDinnerRepository>();
            services.AddScoped<JwtService>();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFitnessApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFitnessApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyHeader().WithOrigins(new[] { "http://localhost:3000", "http://localhost:3001", "http://localhost:3002", "https://localhost:3000", "http://localhost:8080" })
            .AllowAnyMethod().AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
