// <copyright file="Program.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

using Coravel;

using Serilog;

using TestTask.Api;
using TestTask.Application;
using TestTask.Application.Web;
using TestTask.Infrastructure;
using TestTask.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScheduler();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebAppServices();

await LoggerConfigure.LogWebHostAsync(async () =>
{
    var app = builder.Build();

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseRequestCancellationLogging();

    app.UseScheduler(app.Configuration);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    await app.RunAsync();
});