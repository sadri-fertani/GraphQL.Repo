using GraphQL.SocialNetwork.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphiQl;
using GraphQL.SocialNetwork.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.SocialNetwork
{
    public class Startup
    {
        public const string GRAPH_QL_ROUTE = "/graphql";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<BlogService>();
            services
                .AddDbContext<AppGraphQLDbContext>();
            services
                .AddCors();
            services
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseGraphiQl(Startup.GRAPH_QL_ROUTE);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
