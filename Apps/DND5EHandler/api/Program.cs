using Domain.Models.Feats;
using infrastructure.Implementations;
using infrastructure.Interfaces;
using service.Implementation;
using service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddNpgsqlDataSource(Environment.GetEnvironmentVariable("pgconn")!,
    dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());

builder.Services.AddScoped<IService<FeatModel>, FeatService>();
builder.Services.AddScoped<IRepository<FeatModel>, FeatRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
