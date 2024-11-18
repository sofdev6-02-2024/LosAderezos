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
    c.AddServer(new OpenApiServer { Url = "/users" }); 
});

builder.Services.AddHttpContextAccessor();

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UserService>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")  && type.Namespace == "Backend.Services"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UserDAO>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DAO")  && type.Namespace == "DB"))
    .AsSelf()
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddHttpClient<UserService>();
builder.Services.AddHttpClient<TokenService>();
builder.Services.AddHttpClient<ProductAPIService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policyBuilder => policyBuilder
        .WithOrigins("http://localhost:5173", "http://localhost:5174")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
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
            c.SwaggerEndpoint("/users/swagger/v1/swagger.json", "Work v1"); 
            c.RoutePrefix = string.Empty;
        }
    );
    
//}
//discomment for final deploy
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseAuthorization();
app.MapControllers();

app.Run();
