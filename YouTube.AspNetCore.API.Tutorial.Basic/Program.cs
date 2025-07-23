using YouTube.AspNetCore.API.Tutorial.Basic.Extensions;
using YouTube.AspNetCore.API.Tutorial.Basic.Filters;
using YouTube.AspNetCore.API.Tutorial.Basic.Middlewares;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilterAttribute>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.LoadServiceExtensions(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomException();
app.UseCustomStatusCodePages();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
