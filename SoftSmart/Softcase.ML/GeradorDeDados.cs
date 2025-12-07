using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softcase.Core;

namespace Softcase.ML;

internal class GeradorDeDados
{
    public static void GerarArquivoCSV(string caminhoArquivo)
    {
        DateTime dataInicial = DateTime.Now.AddYears(-1);
        DateTime dataFinal = DateTime.Now;
        int vagasTotais = 250;
        var rand = new Random();

        List<DadosPatio> Lista_Patio = new();

        Console.WriteLine("=== Gerador de Dados para IA ===");

        Console.WriteLine("Criando Arquivo....");

        try
        {
            for (DateTime i = dataInicial; i <= dataFinal; i = i.AddHours(1))
            {
                float ocupacao = 0;
                float chuva = 0;
                float evento = 0;
                float temperatura = rand.Next(15, 31);

                // ocupacao
                if (i.Hour < 6 && i.Hour >= 0)
                {
                    ocupacao = rand.Next(5, 16);
                }
                else if (i.Hour < 8)
                {
                    ocupacao = rand.Next(20, 41);
                }
                else if (i.Hour < 18)
                {
                    ocupacao = rand.Next(70, 96);
                }
                else
                {
                    ocupacao = rand.Next(30, 61);
                }

                //chuva 
                var randomChuva = rand.Next(0, 101);
                if (randomChuva < 20)
                {
                    chuva = 1;
                    temperatura -= 3;
                    float aumento = rand.Next(10, 20);
                    ocupacao += aumento;
                }

                //evento 
                if (((int)i.DayOfWeek == 5 || (int)i.DayOfWeek == 6) && (i.Hour >= 19 && i.Hour <= 23))
                {
                    var randomEvento = rand.Next(0, 101);

                    if (randomEvento <= 40)
                    {
                        evento = 1;
                        ocupacao = rand.Next(95, 100);
                    }
                }

                if (ocupacao > 100) ocupacao = 100;
                if (ocupacao < 0) ocupacao = 0;

                var patio = new DadosPatio(
                        i.Hour,
                        (int)i.DayOfWeek,
                        temperatura,
                        chuva,
                        evento,
                        (i.DayOfYear % 50 == 0) ? 1 : 0,
                        ocupacao
                    );

                Lista_Patio.Add(patio);

            }

            string caminhoNovoArquivo = Path.Combine(Environment.CurrentDirectory, "DadosPatio.csv");

            using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.WriteLine("Hora,DiaDaSemana,Temperatura,Chuva,EventoNaRegiao,EhFeriado,Ocupacao");

                foreach (DadosPatio dado in Lista_Patio)
                {
                    escritor.WriteLine($"{dado.Hora},{dado.DiaDaSemana},{dado.Temperatura},{dado.Chuva},{dado.EventoNaRegiao},{dado.EhFeriado},{dado.Ocupacao}");
                }
            }

            Console.WriteLine($"Arquivo Criado com Sucesso em: {caminhoNovoArquivo}");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Deu erro: ");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}
