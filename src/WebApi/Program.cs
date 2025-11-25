using Application;
using FluentValidation.AspNetCore;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();
builder.Services
    .AddApplication()   
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

// FluentValidation automatic integration
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

var app = builder.Build();


app.AddExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
