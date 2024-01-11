using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Zthombe_API.Models;



var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://192.168.1.2:5000");


//const string corsPolicyName = "ApiCORS";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(corsPolicyName, policy =>
//    {
//        policy.WithOrigins("https://localhost:4200");
//    });
//});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Zthombe API",
        Version = "1.0",
        Description = "Product API for Zthombe"
    });
});
builder.Services.AddDbContext<ZthombeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Zthombe")));
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddMvc()
    .AddControllersAsServices()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

//app.UseCors(corsPolicyName); // This should be above the UseStaticFiles();

//app.UseStaticFiles(); // Below the UseCors();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
