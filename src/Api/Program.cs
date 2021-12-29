using Api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Add(new SomeWrapperTypeModelBinderProvider());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
    options.MapType<SomeWrapperType>(() => new OpenApiSchema { Type = "string" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));

app.MapGet("/sample/minimal", (SomeWrapperType wrapper) => Results.Ok(wrapper.Value));
app.MapControllers();

app.Run();