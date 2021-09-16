using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;

namespace NLA.ODATA.EF.API
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
            services //.AddEntityFrameworkNpgsql()
                    .AddDbContext<BooksDBContext>(opt =>
                        opt.UseNpgsql(Configuration.GetConnectionString("CustomerDBConnection"))
                        );

            services.AddControllers()
                // add OData capability to controllers
                .AddOData(options => options.Select().Filter().Count().OrderBy().Expand()
                            .SetMaxTop(100) // enable usage of $top
                            .AddRouteComponents("odata", GetEdmModel()) // enable OData routing
                            )
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NLA.ODATA.EF.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NLA.ODATA.EF.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Support OData EDM
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Book>("Books"); // must match BooksController
            modelBuilder.EntitySet<Author>("Authors"); // must match AuthorsController

            modelBuilder.EntityType<Book>()
                        .Action("AddRating")
                        .Parameter<int>("Rating");
            return modelBuilder.GetEdmModel();
        }
    }
}
