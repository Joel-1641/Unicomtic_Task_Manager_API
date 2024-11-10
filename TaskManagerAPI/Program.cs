using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TaskManagerAPI.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "CORSOpenPolicy",
        builder =>
        {
            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSOpenPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
