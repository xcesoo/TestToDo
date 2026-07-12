using System.Text.Json.Serialization;
using TestToDo.Api.Extensions;
using TestToDo.Api.Middlewares;
using TestToDo.Application;
using TestToDo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionsHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddSwaggerConfiguration();


builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwaggerUi();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();