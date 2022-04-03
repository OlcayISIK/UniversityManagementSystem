using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UMS.Api.Helpers;
using UMS.Core.InternalDtos;
using UMS.Core;
using UMS.Data.EF;
using UMS.Data.Entities;
using UMS.Core.Enums;
using UMS.Business.Helpers;
using UMS.Api.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

namespace UMS.Api
{
    public class Startup
    {
        private AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _appSettings = new AppSettings();
            Configuration.Bind(_appSettings);
            services.AddSingleton(_appSettings);

            // handle database connection
            services.AddDbContext<Context>(options => { options.UseSqlServer(_appSettings.DatabaseConnectionString, x => x.MigrationsAssembly("UMS.Data.EF")); });
            services.AddTransient(typeof(CustomMapper));
            services.AddAutoMapper(typeof(AutoMapperMappingProfile));

            services.AddHttpContextAccessor();
            services.AddCors();
            services.AddSignalR();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            // handle authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Constants.AuthenticationSchemes.Student, x =>
            {
                // this section is for authenticating signalR requests
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/refreshHub")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                // TODO look into this
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.TokenOptions.StudentSecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            }).AddJwtBearer(Constants.AuthenticationSchemes.Teacher, x =>
            {
                // this section is for authenticating signalR requests
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/refreshHub")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                // TODO look into this
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.TokenOptions.TeacherSecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            }).AddJwtBearer(Constants.AuthenticationSchemes.StudentRespresentative, x =>
            {
                // this section is for authenticating signalR requests
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/refreshHub")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                // TODO look into this
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.TokenOptions.StudentRepresentativeSecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(Constants.AuthenticationSchemes.Student, new OpenApiInfo { Title = "UMS User Api", Version = "v1" });
                x.SwaggerDoc(Constants.AuthenticationSchemes.StudentRespresentative, new OpenApiInfo { Title = "UMS Student Respresentative Api", Version = "v1" });
                x.SwaggerDoc(Constants.AuthenticationSchemes.Teacher, new OpenApiInfo { Title = "UMS Teacher Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
                x.DocumentFilter<SwaggerAddEnumDescriptions>();
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UMS.Api", Version = "v1" });
            });

            services.AddDistributedRedisCache(options => { options.Configuration = _appSettings.RedisConnectionString; });
            ConfigureDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UMS.Api v1"));
            }
            if (env.IsProduction())
            {
                ServiceLocator.SetProductionEnvironment();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware(typeof(RequestRewindMiddleware));
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseWebSockets();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapHub<RefreshHub>("/refreshhub");
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(endpoints =>
            {
                endpoints.SwaggerEndpoint($"/swagger/{Constants.AuthenticationSchemes.Student}/swagger.json", "UMS User API");
                endpoints.SwaggerEndpoint($"/swagger/{Constants.AuthenticationSchemes.StudentRespresentative}/swagger.json", "UMS Student Respresentative API");
                endpoints.SwaggerEndpoint($"/swagger/{Constants.AuthenticationSchemes.Teacher}/swagger.json", "UMS Teacher API");
                endpoints.RoutePrefix = string.Empty;
            });

            ServiceLocator.Initialize(app.ApplicationServices, _appSettings);
            UpdateDatabase(_appSettings.DatabaseConnectionString);
            CreateFileSystemDirectories();
        }
        /// <summary>
        /// Registers all types to be used in dependency injection
        /// </summary>
        private void ConfigureDependencies(IServiceCollection services)
        {
            AutomaticInjection(services, "UMS.Repository");
            AutomaticInjection(services, "UMS.Business");
        }

        /// <summary>
        /// Searches given assembly and automatically injects found dependencies.
        /// </summary>
        private void AutomaticInjection(IServiceCollection services, string assemblyName)
        {
            var types = Assembly.Load(assemblyName).DefinedTypes.ToList();
            foreach (var type in types)
            {
                if (type.IsGenericType)
                    continue;
                var implementedInterfaces = type.ImplementedInterfaces.ToList();
                if (implementedInterfaces.Count != 0)
                {
                    foreach (var implementedInterface in implementedInterfaces)
                    {
                        if (implementedInterface.Name[0] == 'I' && type.Name.StartsWith(implementedInterface.Name.Substring(1)))
                        {
                            services.AddScoped(Type.GetType(implementedInterface + ", " + assemblyName),
                                Type.GetType(type + ", " + assemblyName));
                            break;
                        }
                    }
                }
            }
        }

        private void UpdateDatabase(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(connectionString);
            using var context = new Context(builder.Options);
            context.Database.Migrate();
        }

        private void CreateFileSystemDirectories()
        {
            Directory.CreateDirectory(Path.Combine(_appSettings.FileSystemImageBasePath));
            Directory.CreateDirectory(Path.Combine(_appSettings.FileSystemAudioBasePath));
        }
    }
}
