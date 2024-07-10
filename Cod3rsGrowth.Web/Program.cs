using Cod3rsGrowth.Web.ModuloDeInjecao;

var builder = WebApplication.CreateBuilder(args);
var servicos = builder.Services;
var stringDeConexao = builder.Configuration.GetConnectionString("StringConexao") ??
    throw new Exception("Não foi possível obter a string de conexão.");

ModuloDeInjecaoWeb.BindService(servicos, stringDeConexao);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
