using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoCoreList.Data.Contexts;
using TodoCoreList.Data.Providers;
using TodoCoreList.Data.Providers.Interface;
using TodoCoreList.DTO.Extensions;
using TodoCoreList.DTO.Mapper;
using TodoCoreList.Service.Services;
using TodoCoreList.Service.Services.Interface;

namespace TodoCoreList.UI
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
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(ValidateModelStateAttribute));
            //}).AddJsonOptions(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore)
            //    .ConfigureApiBehaviorOptions(options =>
            //    {
            //        options.SuppressMapClientErrors = true;
            //        options.SuppressModelStateInvalidFilter = true;
            //    });

            services.AddControllersWithViews();

            /*
             * Transient : Her istendiğinde oluşturulur.
             * Scoped    : istemci isteği (bağlantı) başına bir kez oluşturulur.
             * Singleton : Sonraki her istek aynı örneği kullanır.
             * 
             * 
             * dotnet tool install --global dotnet-ef --version 3.1.3
             * dotnet ef migrations remove 
             * dotnet ef database update
             * dotnet ef migrations add InitialCreate
            */

            services.AddDbContext<DbContext, TodoContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITodoProvider, TodoProvider>();
            services.AddScoped<ITodoService, TodoService>();


            AutoMapperExtensions.Init(MappingConfiguration.InitializeAutoMapper().CreateMapper());
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
