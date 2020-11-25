using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate.Execution.Configuration;
using HotChocolate.AspNetCore;
using simple_graphql_app.Data;

namespace simple_graphql_app
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source = GraphQLAppDB"));

            services.AddGraphQL(
                        SchemaBuilder.New()
                            .AddQueryType<Query>()
                            .Create(),
                        new QueryExecutionOptions { ForceSerialExecution = true });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase.Initialize(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL();
            app.UsePlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/playground", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

    }
}
