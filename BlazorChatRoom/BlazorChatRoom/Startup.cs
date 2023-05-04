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

                // ���������ļ��е����ݿ����ͣ�ѡ��ͬ�����ݿ����ӷ�ʽ
                if (Configuration.GetConnectionString("SqlType") == "MySql")
                {
                    options.UseMySql(sqlConnectStr, new MySqlServerVersion(new Version(8, 0)));
                }

                if (Configuration.GetConnectionString("SqlType") == "SqlServer")
                {
                    options.UseSqlServer(sqlConnectStr);
                }
            });
            // ��� ASP.NET Core Identity����֤����Ȩ������
            // ʹ�� SignIn.RequireConfirmedAccount ���������Ƿ�Ҫ��ȷ���˻���
            // IdentityUser ����ָ���û�����ģ�͡�
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
            // ��������Ա�쳣ɸѡ����ӵ� MVC �������С� 
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
                // �� Blazor Hub ӳ�䵽 SignalR �ս�㡣
                // �������ͻ��˾Ϳ���ʹ�� SignalR Э��������������е� Blazor Ӧ�ó���ͨ���ˡ�
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                // ���� Hub ChatHub Endpoint...
                endpoints.MapHub<ChatHub>(ChatHub.HubPath);
            });
        }
    }
}
