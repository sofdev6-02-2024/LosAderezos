using Backend.Services;
using DB;

DBConnector.OpenConnection();

// Delete to conserve persistency.
DBInjector.TruncateAllTables();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProductService>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")  && type.Namespace == "Backend.Services"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());
builder.Services.AddControllers();

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProductDAO>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("DAO")  && type.Namespace == "DB"))
    .AsSelf()
    .AsImplementedInterfaces()
    .WithScopedLifetime());
builder.Services.AddControllers();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
        { 
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Work v1"); 
            c.RoutePrefix = string.Empty;
        }
    );
    
}
app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();