using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;
using System.Linq;
using Knewin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Knewin.Infra.IoC.ContainerIOC;
using Knewin.Domain.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AutoMapper;

namespace Knewin
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

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Knewin API",
                    Description = "API simples com autenticação JWT",
                    TermsOfService = new Uri("https://www.knewin.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Pedro Ivo",
                        Email = "pedroivossantos@gmail.com",
                        Url = new Uri("https://exemplo.com.br"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licenciado por knewin",
                        Url = new Uri("https://www.knewin.com/"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                    },
                        new string[] { }
                    }
                });
            });

            services.AddDbContext<KnewinContext>(opt => opt.UseInMemoryDatabase("Knewin"));

            //DI
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Seed the database.
                var context = serviceScope.ServiceProvider.GetService<KnewinContext>();
                PopularUsuarios(context);
                PopularCidades(context);
                PopularFronteiras(context);
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cidade API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }

#region PopularBancoDados


    
#endregion
        private void PopularUsuarios(KnewinContext context)
        {
            var user1 = new User { Id = 1, Username = "admin", Password = "admin", Role = "manager" };
            context.Usuarios.Add(user1);

            var user2 = new User { Id = 2, Username = "Pedro", Password = "1234", Role = "employee" };
            context.Usuarios.Add(user2);

            context.SaveChanges();
        }

        private void PopularCidades(KnewinContext context)
        {
            var cidade1 = new Cidade { Id = 1, Nome = "Cidade1", Habitantes = 477.798, };
            context.Cidades.Add(cidade1);

            var cidade2 = new Cidade { Id = 2, Nome = "Cidade2", Habitantes = 242.927 };
            context.Cidades.Add(cidade2);

            var cidade3 = new Cidade { Id = 3, Nome = "Cidade3", Habitantes = 168.259 };
            context.Cidades.Add(cidade3);

            var cidade4 = new Cidade { Id = 4, Nome = "Cidade4", Habitantes = 168.259 };
            context.Cidades.Add(cidade4);

            var cidade5 = new Cidade { Id = 5, Nome = "Cidade5", Habitantes = 168.259 };
            context.Cidades.Add(cidade5);

            var cidade6 = new Cidade { Id = 6, Nome = "Cidade6", Habitantes = 168.259 };
            context.Cidades.Add(cidade6);

            var cidade7 = new Cidade { Id = 7, Nome = "Cidade7", Habitantes = 168.259 };
            context.Cidades.Add(cidade7);

            var cidade8 = new Cidade { Id = 8, Nome = "Cidade8", Habitantes = 168.259 };
            context.Cidades.Add(cidade8);

            var cidade9 = new Cidade { Id = 9, Nome = "Cidade9", Habitantes = 168.259 };
            context.Cidades.Add(cidade9);

            var cidade10 = new Cidade { Id = 10, Nome = "Cidade10", Habitantes = 168.259 };
            context.Cidades.Add(cidade10);

            var cidade88 = new Cidade { Id = 11, Nome = "Cidade88", Habitantes = 254.889 };
            context.Cidades.Add(cidade88);

            context.SaveChanges();
        }

        private void PopularFronteiras(KnewinContext context)
        {
            var fronteira1 = new Fronteira { Cidade1 = 1, Cidade2 = 2 };
            context.Fronteiras.Add(fronteira1);

            var fronteira2 = new Fronteira { Cidade1 = 1, Cidade2 = 3 };
            context.Fronteiras.Add(fronteira2);

            var fronteira3 = new Fronteira { Cidade1 = 2, Cidade2 = 1 };
            context.Fronteiras.Add(fronteira3);
            var fronteira4 = new Fronteira { Cidade1 = 2, Cidade2 = 5 };
            context.Fronteiras.Add(fronteira4);

            var fronteira5 = new Fronteira { Cidade1 = 3, Cidade2 = 1 };
            context.Fronteiras.Add(fronteira5);
            var fronteira6 = new Fronteira { Cidade1 = 3, Cidade2 = 4 };
            context.Fronteiras.Add(fronteira6);

            var fronteira7 = new Fronteira { Cidade1 = 4, Cidade2 = 3 };
            context.Fronteiras.Add(fronteira7);
            var fronteira8 = new Fronteira { Cidade1 = 4, Cidade2 = 8 };
            context.Fronteiras.Add(fronteira8);

            var fronteira9 = new Fronteira { Cidade1 = 8, Cidade2 = 4 };
            context.Fronteiras.Add(fronteira9);

            var fronteira10 = new Fronteira { Cidade1 = 5, Cidade2 = 2 };
            context.Fronteiras.Add(fronteira10);
            var fronteira11 = new Fronteira { Cidade1 = 5, Cidade2 = 6 };
            context.Fronteiras.Add(fronteira11);
            var fronteira12 = new Fronteira { Cidade1 = 5, Cidade2 = 7 };
            context.Fronteiras.Add(fronteira12);

            var fronteira13 = new Fronteira { Cidade1 = 7, Cidade2 = 5 };
            context.Fronteiras.Add(fronteira13);
            var fronteira14 = new Fronteira { Cidade1 = 7, Cidade2 = 10 };
            context.Fronteiras.Add(fronteira14);

            var fronteira15 = new Fronteira { Cidade1 = 10, Cidade2 = 7 };
            context.Fronteiras.Add(fronteira15);

            var fronteira16 = new Fronteira { Cidade1 = 6, Cidade2 = 5 };
            context.Fronteiras.Add(fronteira16);
            var fronteira17 = new Fronteira { Cidade1 = 6, Cidade2 = 9 };
            context.Fronteiras.Add(fronteira17);

            var fronteira18 = new Fronteira { Cidade1 = 9, Cidade2 = 6 };
            context.Fronteiras.Add(fronteira18);

            var fronteira88 = new Fronteira { Cidade1 = 11, Cidade2 = 10 };
            context.Fronteiras.Add(fronteira88);
            var fronteira89 = new Fronteira { Cidade1 = 11, Cidade2 = 1 };
            context.Fronteiras.Add(fronteira89);
            var fronteira90 = new Fronteira { Cidade1 = 11, Cidade2 = 6 };
            context.Fronteiras.Add(fronteira90);
            var fronteira91 = new Fronteira { Cidade1 = 11, Cidade2 = 9 };
            context.Fronteiras.Add(fronteira91);

            context.SaveChanges();
        }
    }
}