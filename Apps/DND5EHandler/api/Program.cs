using infrastructure.Implementations;
using infrastructure.Interfaces;
using infrastructure.Models.Feats;
using service.Implementation;
using service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddNpgsqlDataSource(Environment.GetEnvironmentVariable("pgconn")!,
    dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());

builder.Services.AddScoped<IService<FeatModel , FeatCreateModelDto>, FeatService>();
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
