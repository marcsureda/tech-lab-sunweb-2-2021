using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApplication2.Data;
using WebApplication2.GraphQL;
using WebApplication2.GraphQL.Items;
using WebApplication2.GraphQL.Lists;
using WebApplication2.GraphQL.Packages;
using WebApplication2.Services;

namespace WebApplication2
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
            services.AddControllers();

            services.AddPooledDbContextFactory<ApiDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://example.com",
                            "http://www.contoso.com");
                    });
            });

            services.AddScoped<PackagesService>();

            services.AddSpaStaticFiles(options => options.RootPath = "ClientApp/build");

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<ItemType>()
                .AddType<ListType>()
                .AddType<PackagesType>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddProjections()
                .AddSorting()
                .AddFiltering()
                .AddInMemorySubscriptions();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApplication2", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseWebSockets();

            app.UseSpaStaticFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");

            app.UseSpa(builder =>
            {
                builder.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    builder.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}