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

            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            // });

            // Register the Swagger generator, defining 1 or more Swagger documents
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
            var cidade1 = new Cidade { Id = 1, Nome = "Florianópolis", Habitantes = 477.798, };
            context.Cidades.Add(cidade1);

            var cidade2 = new Cidade { Id = 2, Nome = "São José", Habitantes = 242.927 };
            context.Cidades.Add(cidade2);

            var cidade3 = new Cidade { Id = 3, Nome = "palhoca", Habitantes = 168.259 };
            context.Cidades.Add(cidade3);

            context.SaveChanges();

            //Fronteiras
            var fronteiraFloripa = new List<Cidade>
            {
                cidade2,
                cidade3
            };

            cidade1.Fronteiras.AddRange(new List<Cidade> { cidade2, cidade3 });
            context.SaveChanges();
            cidade2.Fronteiras.Add(cidade1);
            context.SaveChanges();
            cidade3.Fronteiras.Add(cidade1);
            context.SaveChanges();

        }

        private void PopularFronteiras(KnewinContext context)
        {
            var cidade = context.Cidades.FirstOrDefaultAsync(x => x.Nome.Equals("Florianópolis"));
            if (cidade != null)
            {

            }
        }
    }
}