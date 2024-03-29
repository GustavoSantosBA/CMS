using cmsWebApi.models.Data.context;
using cmsWebApi.models.Data.repository;
using cmsWebApi.models.Domain.entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cmsWebApi
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
            //services.AddControllers().AddJsonOptions(x =>  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "cmsWebApi", Version = "v1" });
            });

            services.AddDbContext<cmsContext>(
                context => context.UseSqlServer("Data Source=megacontrolapp.com,11433;Initial Catalog=dblocal;User ID=cms;Password=a52l3^qX")
            );

            // DependÍncias
            services.AddScoped<IRepositoryBase<Grades>, RepositoryBase<Grades>>();
            services.AddScoped<IRepositoryBase<Student>, RepositoryBase<Student>>();
            services.AddScoped<IRepositoryBase<Subjects>, RepositoryBase<Subjects>>();
            services.AddScoped<IRepositoryBase<Teacher>, RepositoryBase<Teacher>>();
            services.AddScoped<IRepositoryBase<Courses>, RepositoryBase<Courses>>();
            // Repositories
            services.AddScoped<CourseRepository>();
            services.AddScoped<GradesRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<SubjectsRepository>();
            services.AddScoped<TeacherRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "cmsWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
