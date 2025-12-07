using System.Diagnostics.Tracing;
using Softcase.Core;
using Softcase.ML;

string caminho = Path.Combine(Environment.CurrentDirectory, "DadosPatio.csv");

try
{
    GeradorDeDados.GerarArquivoCSV(caminho);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

Console.ReadKey();



