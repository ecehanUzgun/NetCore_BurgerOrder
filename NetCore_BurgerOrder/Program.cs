using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCore_BurgerOrder.Models.Context;
using NetCore_BurgerOrder.Models.Entities;

namespace NetCore_BurgerOrder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DB
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
            });

            // Cookie Manager: ��erisinde k���k boyutlu verileri tutan ve bu verilere sadece browser'dan ula�an k���k yap�lard�r.
            builder.Services.ConfigureApplicationCookie(cookie =>
            {
                cookie.Cookie = new CookieBuilder
                {
                    Name = "LoginCookie"
                };

                cookie.LoginPath = new PathString("/Home/Login"); //kimlik do�rulama gerektiren bir sayfaya eri�im yap�l�rken kullan�c� giri� yapmam��sa, kullan�c�n�n y�nlendirilece�i giri� sayfas�n�n yolunu belirtir
                cookie.SlidingExpiration = true;
                cookie.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });

            // AddIdentity AppUser AppRole 
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjectContext>();

            builder.Services.AddSession(x =>
            {
                x.Cookie.Name = "Sepet_Session";
                x.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //System.InvalidOperationException: 'Session has not been configured for this application or request.' hatas� Session eklenmedi�inde olu�ur.
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//kimlik y�netimi rol bazl� oturum i�in tan�mlanmas� gereken servis
            app.UseAuthorization();//oturum

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }
}
