using AutoMapper;
using COREVUE.Models;
using COREVUE.Models.Entities;
using COREVUE.Repositories;
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

namespace COREVUE
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
            services.AddCors();
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });

            services.AddDbContext<DBContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddAutoMapper(typeof(Startup));

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

                if (user.Token == null)
                    context.Fail("Invalid Token");

                var requestToken = context.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
                if (user.Token != requestToken)
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
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "ClientApp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });
        }
    }
}
