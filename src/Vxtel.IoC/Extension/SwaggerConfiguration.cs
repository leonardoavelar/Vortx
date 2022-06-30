﻿using Microsoft.OpenApi.Models;

namespace Vxtel.IoC.Extension
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureServicesSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VxTel.WebApi", Version = "v1" });
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VxTel.WebApi v1"));
            }
        }
    }
}
