using DB;
using Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ProductInputDAO dao = new ProductInputDAO();

ProductInput input = new ProductInput
                            {
                                Time = DateTime.Now,
                                Code = "123",
                                ProductName = "lechitaaaaaa",
                                Quantity = 123,
                                IncomePrice = 13.0,
                                Subsidiary = "Sucursal del diavlo",
                                UserEmail = "example@example.com",
                                UserName = "Juanito",
                                UserRol = "Owner",
                                UserPhoneNumber = "1234"
                            };


dao.Write(input);

app.MapGet("/", () => "Hello World!");

app.Run();
