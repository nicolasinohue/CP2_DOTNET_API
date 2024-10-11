using CP2.IoC;
using CP2.Data.AppData;  // Certifique-se de que você está incluindo o DbContext correto
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure o ApplicationContext e especifique o assembly de migrações
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"),  // UseOracle para o Oracle DB
    sqlOptions => sqlOptions.MigrationsAssembly("CP2.Data")));  // Defina o assembly de migrações como CP2.Data

// Iniciar a configuração do Bootstrap
Bootstrap.Start(builder.Services, builder.Configuration);

// Adicionar serviços e configurações
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();