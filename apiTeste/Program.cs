using apiTeste.Context;
using apiTeste.Filter;
using apiTeste.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Conexão com o SQL Server
string? sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<apiTesteContext>(options =>
    options.UseSqlServer(sqlConnection)
);

// Necessario para os Services
builder.Services.AddTransient<IMeuService, Saudaçao>();
builder.Services.AddTransient<IMeuService2, Saudaçao2>();

// Ler variaveis de ambiente do appsettins.json
var valor = builder.Configuration["chave"];
var valor2 = builder.Configuration["chaveComposta:index1"];

// Serviço de filtro das requests
builder.Services.AddScoped<LoggingFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/* Console
 *  dotnet ef migrations add nome
 *  dotnet ef migrations remove nome
 *  dotnet ef database update
 */
/*Package Console
 * add-migration nome
 * remove-migration nome
 * update-database
 */

