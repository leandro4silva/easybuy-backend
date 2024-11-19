using CompraFacil.Application;
using CompraFacil.Infrastructure;
using CompraFacil.Infrastructure.Extensions;
using CompraFacil.Infra.Data.MongoDB;

var builder = WebApplication.CreateBuilder(args);

var appConfigs = builder.AddAppConfigs();

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
builder.Services.AddMongoDB(appConfigs);

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
