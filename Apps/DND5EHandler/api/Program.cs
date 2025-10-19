using System.Text.Json.Serialization;
using Core.Interfaces;
using Core.Models.Feats;
using Core.Service.Implementation;
using infrastructure.Implementations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddNpgsqlDataSource(Environment.GetEnvironmentVariable("pgconn")!,
    dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());

builder.Services.AddScoped<IRepository<FeatModel>, FeatRepository>();
builder.Services.AddScoped<IService<FeatModel>, FeatService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddControllers();
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