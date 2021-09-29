using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using Todo.Common;
using Todo.DependencyInjection;
using Todo.FluentMigrations.DbMigrations;

namespace Todo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private ConnectionOptions _connOptions;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _connOptions = new ConnectionOptions(Configuration.GetConnectionString(ConnectionOptions.FieldsName.ConnPostgres));

            services.AddResponseCompression(options => 
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });
            //services.AddResponseCaching();

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastro de Usuários", Version = "v1" });
            });

            new DependencyResolver().Resolver(services);
            ConfigureFluentMigrator(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro de Usuário API V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(
                x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            migrationRunner.MigrateUp();
        }

        private void ConfigureFluentMigrator(IServiceCollection services)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(
                builder => builder
                .WithVersionTable(new TableVersionMigration())
                .AddPostgres()
                .WithGlobalConnectionString(_connOptions.ConnPostgres)
                .ScanIn(typeof(TableVersionMigration).Assembly).For.Migrations());
        }
    }
}
