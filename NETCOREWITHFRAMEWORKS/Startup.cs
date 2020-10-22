using AutoMapper;
using NETCOREWITHFRAMEWORKS.Models;
using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.Repositories;
using NETCOREWITHFRAMEWORKS.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VueCliMiddleware;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace NETCOREWITHFRAMEWORKS
{
    public class Startup
    {
        private enum ClientApp
        {
            Angular, Vue
        }
        private ClientApp client;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
              .AddNewtonsoftJson();
            services.AddAuthentication(s =>
            {
                s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       LifetimeValidator = LifetimeValidator,
                       ClockSkew = TimeSpan.Zero,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecurityKey"])),
                       ValidateLifetime = true,
                       ValidateAudience = false,
                       ValidateIssuer = false
                   };
                   options.Events = new JwtBearerEvents
                   {
                       OnTokenValidated = OnTokenValidated
                   };
               });
            services.AddSpaStaticFiles(configuration =>
            {
                //Experimental
                char key;
                do
                {
                    Console.WriteLine("Please Select a Client App. (Angular: A-a, Vue: V-v)\n");
                    key = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");

                } while (key != 'A' && key != 'a' && key != 'V' && key != 'v');

                if (key.Equals('A') || key.Equals('a'))
                    client = ClientApp.Angular;

                if (key.Equals('V') || key.Equals('v'))
                    client = ClientApp.Vue;

                if (client == ClientApp.Angular)
                    configuration.RootPath = "ClientApps/Angular/dist";
                if (client == ClientApp.Vue)
                    configuration.RootPath = "ClientApps/Vue";
            });

            services.AddDbContext<DBContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Startup));
        }
        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }
        private Task OnTokenValidated(TokenValidatedContext context)
        {
            try
            {
                var a = context.Principal.Claims.Select(s => s.Value).ToList();
                int.TryParse(context.Principal.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value, out int userId);
                var userRepo = new Repository<User>(new DBContext(Configuration));
                var user = userRepo.Get().FirstOrDefault(u => u.Id == userId);

                if (user == null)
                    context.Fail("Invalid User");

                if (user != null && user.Token == null)
                    context.Fail("Invalid Token");

                var requestToken = context.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
                if (user != null && user.Token != requestToken)
                    context.Fail("Invalid Token");
            }
            catch
            {
                context.Fail("Invalid Token");
            }

            return Task.CompletedTask;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(s =>
            {
                s.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (client == ClientApp.Vue)
                {
                    if (env.IsDevelopment())
                    {
                        spa.Options.SourcePath = "ClientApps/Vue";
                        spa.UseVueCli(npmScript: "serve", port: 8080);
                    }
                    else
                        spa.Options.SourcePath = "dist";
                }

                if (client == ClientApp.Angular)
                {
                    spa.Options.SourcePath = "ClientApps/Angular";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                }

            });
        }
    }
}
