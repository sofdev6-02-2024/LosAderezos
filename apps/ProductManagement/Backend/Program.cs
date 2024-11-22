using AutoMapper;
using Backend.Mappers;
using Backend.Services;
using DB;
using Microsoft.OpenApi.Models;

DBConnector.OpenConnection();

// Delete to conserve persistency.
DBInjector.TruncateAllTables();
DBInjector.InjectData();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Work", Version = "v1" });
    c.AddServer(new OpenApiServer { Url = "/products" });  // Añade el prefijo a las rutas
});
builder.Services.AddHttpContextAccessor();
builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProductService>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")  && type.Namespace == "Backend.Services"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CategoryProfile));


builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProductDAO>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DAO")  && type.Namespace == "DB"))
    .AsSelf()
    .AsImplementedInterfaces()
    .WithScopedLifetime());
builder.Services.AddControllers();

builder.Services.AddHttpClient<UserAPIService>();

builder.Services.AddCors(policyBuilder =>
{
    policyBuilder.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:5173", "http://localhost:5174")
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});



var app = builder.Build();
/*
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{*/
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/products/swagger/v1/swagger.json", "Work v1");
    c.RoutePrefix = string.Empty;
});
    
//}
// discomment for final deployment

app.MapGet("/", () => "Hello World!");
app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
