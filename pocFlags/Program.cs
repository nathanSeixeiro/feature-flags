using Microsoft.FeatureManagement;
using pocFlags;

var builder = WebApplication.CreateBuilder(args);

// Configurando a injeção do appsettings.json para ser acessado no código
builder.Services.Configure<FeatureFlagsSettings>(builder.Configuration.GetSection("ModelFeatures"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFeatureManagement();

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