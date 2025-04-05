using Deadline.Api.Configurations;
using Tenon.AspNetCore.OpenApi.Extensions;

namespace Deadline.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddApiVersioningConfiguration();
        if (builder.Environment.IsDevelopment())
            builder.Services.AddScalarOpenApi(builder.Configuration.GetSection("ScalarUI"));
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseScalarOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}