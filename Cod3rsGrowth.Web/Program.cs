using Cod3rsGrowth.Web.Extensoes;
using Cod3rsGrowth.Web.ModuloDeInjecao;
using Microsoft.Extensions.FileProviders;

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

app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true });

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    EnableDirectoryBrowsing = true
});

app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();