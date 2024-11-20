using CompraFacil.Application;
using CompraFacil.Infrastructure;
using CompraFacil.Infrastructure.Extensions;
using CompraFacil.Infra.Data.MongoDB;
using CompraFacil.Infra.MessageBus;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var appConfigs = builder.AddAppConfigs();

await builder.Services.AddRabbitMqAsync(appConfigs);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
        options.SuppressInferBindingSourcesForParameters = true
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddMongoDB(appConfigs, builder.Configuration);

builder.Services.AddSwaggerGen(setup => {
    setup.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Compra Facil Api",
        Version = "v1"
    });
    setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });
    var scheme = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                { scheme, Array.Empty<string>() }
            });
});

builder.Services
    .AddApiVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
