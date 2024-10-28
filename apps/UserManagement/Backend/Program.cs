using DB;
using Backend.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

DBConnector.OpenConnection();
DBInjector.TruncateAllTables();
app.Run();