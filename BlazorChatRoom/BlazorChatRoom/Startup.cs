using BlazorChatRoom.Areas.Identity;
using BlazorChatRoom.Data;
using BlazorChatRoom.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatRoom
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var sqlConnectStr = Configuration.GetConnectionString("DefaultConnection");

                // 根据配置文件中的数据库类型，选择不同的数据库连接方式
                if (Configuration.GetConnectionString("SqlType") == "MySql")
                {
                    options.UseMySql(sqlConnectStr, new MySqlServerVersion(new Version(8, 0)));
                }

                if (Configuration.GetConnectionString("SqlType") == "SqlServer")
                {
                    options.UseSqlServer(sqlConnectStr);
                }
            });
            // 添加 ASP.NET Core Identity（认证和授权）服务，
            // 使用 SignIn.RequireConfirmedAccount 参数设置是否要求确认账户。
            // IdentityUser 类型指定用户数据模型。
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            // Blazor Server
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            // 将开发人员异常筛选器添加到 MVC 控制器中。 
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // 将 Blazor Hub 映射到 SignalR 终结点。
                // 这样，客户端就可以使用 SignalR 协议与服务器上运行的 Blazor 应用程序通信了。
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                // 开启 Hub ChatHub Endpoint...
                endpoints.MapHub<ChatHub>(ChatHub.HubPath);
            });
        }
    }
}
