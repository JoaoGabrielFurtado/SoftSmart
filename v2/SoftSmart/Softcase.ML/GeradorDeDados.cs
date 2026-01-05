using Softcase.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Softcase.ML;

public class GeradorDeDados
{
    public static void GerarArquivoCSV(string caminhoArquivo)
    {
        // gerar 50.000 linhas de dados simulados (qs 6 anos atras)
        int totalLinhasDesejadas = 50000;
        DateTime dataInicial = DateTime.Now.AddHours(-totalLinhasDesejadas);
        DateTime dataFinal = DateTime.Now;

        // Capacidade patio
        int capacidadeMaxima = 250;

        var rand = new Random();
        List<DadosPatio> Lista_Patio = new();

        Console.WriteLine("=== Gerador de Dados Complexos para IA (V2) ===");
        Console.WriteLine($"Gerando {totalLinhasDesejadas} registros de histórico simulado...");

        try
        {
            for (DateTime dataAtual = dataInicial; dataAtual <= dataFinal; dataAtual = dataAtual.AddHours(1))
            {
                // TEMPERATURA SAZONAL 
                // simular estações do ano 
                double sazonalidade = Math.Cos((dataAtual.Month + 1) / 12.0 * 2 * Math.PI);
                float tempBase = 24f + (float)(sazonalidade * 5); 

                // Variação Diária 
                if (dataAtual.Hour >= 10 && dataAtual.Hour <= 16) tempBase += rand.Next(2, 5);
                if (dataAtual.Hour >= 0 && dataAtual.Hour <= 5) tempBase -= rand.Next(2, 5);

                // Aleatório na temperatura
                float temperatura = tempBase + rand.Next(-3, 4);


                // VARIÁVEIS BOOLEANAS (Chuva, Feriado, Evento)

                // Chuva: 15% de chance base, aumenta no verão (Jan-Mar)
                int chanceChuva = (dataAtual.Month <= 3 || dataAtual.Month >= 11) ? 25 : 10;
                float chuva = (rand.Next(0, 100) < chanceChuva) ? 1 : 0;
                if (chuva == 1) temperatura -= rand.Next(1, 4); // Chuva derruba temp

                // Feriado
                float ehFeriado = EhFeriadoBR(dataAtual) ? 1 : 0;

                // Evento
                // Maior chance Sexta/Sábado à noite. Menor chance dias úteis.
                float evento = 0;
                int diaSemana = (int)dataAtual.DayOfWeek;
                int hora = dataAtual.Hour;

                // Base chance de evento
                int chanceEvento = 1; // 1% padrão

                if (ehFeriado == 1) chanceEvento = 30; // Feriados tem shows/eventos
                if (diaSemana >= 5 && hora >= 18 && hora <= 22) chanceEvento = 40; // Sex/Sab a noite
                if (diaSemana == 0 && hora >= 14 && hora <= 18) chanceEvento = 20; // Dom a tarde

                if (rand.Next(0, 100) < chanceEvento) evento = 1;


                // 3. CÁLCULO DE OCUPAÇÃO (O Cérebro da Simulação)
                // Define uma curva base dependendo se é dia Útil ou Fim de Semana
                int ocupacaoBase = 0;

                bool ehFimDeSemana = (diaSemana == 0 || diaSemana == 6);

                if (!ehFimDeSemana && ehFeriado == 0)
                {
                    // === DIA ÚTIL ===
                    // Madrugada vazia, Pico manha, Almoço, Pico tarde, Noite cai
                    if (hora < 6) ocupacaoBase = rand.Next(5, 15);
                    else if (hora < 8) ocupacaoBase = rand.Next(20, 60); // Chegada
                    else if (hora < 18) ocupacaoBase = rand.Next(180, 220); // Horário comercial cheio
                    else if (hora < 22) ocupacaoBase = rand.Next(50, 100); // Happy hour/Faculdade
                    else ocupacaoBase = rand.Next(15, 30);
                }
                else
                {
                    // === FIM DE SEMANA OU FERIADO ===
                    // Acorda tarde, pico a tarde, noite agitada se tiver evento
                    if (hora < 10) ocupacaoBase = rand.Next(5, 20);
                    else if (hora < 19) ocupacaoBase = rand.Next(80, 150); // Passeio
                    else ocupacaoBase = rand.Next(40, 80);
                }

                // === APLICAR MODIFICADORES ===

                // 1. Fator Chuva: Em dia útil, chuva aumenta ocupação (vão de carro).
                // No FDS, chuva diminui (ficam em casa).
                if (chuva == 1)
                {
                    if (!ehFimDeSemana) ocupacaoBase += rand.Next(10, 30);
                    else ocupacaoBase -= rand.Next(10, 40);
                }

                // 2. Fator Evento: Explosão de ocupação
                if (evento == 1)
                {
                    ocupacaoBase = rand.Next(230, 255); // Quase lotação máxima
                }

                // 3. Fator Temperatura Extrema
                // Muito calor no FDS aumenta ocupação (se for praia/parque) ou shopping (ar condicionado)
                if (ehFimDeSemana && temperatura > 32) ocupacaoBase += 20;


                // === FINALIZAÇÃO E RUÍDO ===
                // Adiciona um "jitter" (tremulação) para não ficar números redondos
                ocupacaoBase += rand.Next(-5, 6);

                // Limites de segurança (Clamping)
                if (ocupacaoBase > capacidadeMaxima) ocupacaoBase = capacidadeMaxima;
                if (ocupacaoBase < 0) ocupacaoBase = 0;


                // ==========================================================
                // 4. CRIAÇÃO DO OBJETO
                // ==========================================================
                var patio = new DadosPatio(
                        hora,
                        diaSemana,
                        temperatura,
                        chuva,
                        evento,
                        ehFeriado,
                        (float)ocupacaoBase // Ocupação final
                    );

                Lista_Patio.Add(patio);
            }

            // GRAVAÇÃO DO ARQUIVO
            string pastaDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string caminhoNovoArquivo = Path.Combine(pastaDesktop, "DadosTreinoV2.csv");

            using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
            {
                // Cabeçalho
                escritor.WriteLine("Hora,DiaDaSemana,Temperatura,Chuva,EventoNaRegiao,EhFeriado,Ocupacao");

                foreach (DadosPatio dado in Lista_Patio)
                {
                    string linha = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        "{0},{1},{2:F1},{3},{4},{5},{6}",
                        dado.Hora,
                        dado.DiaDaSemana,
                        dado.Temperatura,
                        dado.Chuva,
                        dado.EventoNaRegiao,
                        dado.EhFeriado,
                        dado.Ocupacao);

                    escritor.WriteLine(linha);
                }
            }

            Console.WriteLine($"Concluído! {Lista_Patio.Count} linhas geradas.");
            Console.WriteLine($"Arquivo salvo em: {caminhoNovoArquivo}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro fatal: {ex.Message}");
        }
    }

    private static bool EhFeriadoBR(DateTime dataAtual)
    {
        DateTime dia = dataAtual.Date;
        int ano = dia.Year;

        // Feriados Fixos Nacionais
        // (Janeiro)
        if (dia.Month == 1 && dia.Day == 1) return true; // Confraternização 

        // (Abril)
        if (dia.Month == 4 && dia.Day == 21) return true; // Tiradentes

        // (Maio)
        if (dia.Month == 5 && dia.Day == 1) return true; // Dia do Trabalho

        // (Setembro)
        if (dia.Month == 9 && dia.Day == 7) return true; // Independência

        // (Outubro)
        if (dia.Month == 10 && dia.Day == 12) return true; // N. Sra. Aparecida

        // (Novembro)
        if (dia.Month == 11 && dia.Day == 2) return true; // Finados
        if (dia.Month == 11 && dia.Day == 15) return true; // Proclamação da República
        if (dia.Month == 11 && dia.Day == 20) return true; // Consciência Negra 

        // (Dezembro)
        if (dia.Month == 12 && dia.Day == 25) return true; // Natal

        DateTime pascoa = CalcularPascoa(ano);

        if (dia == pascoa.AddDays(-48)) return true; // Segunda de Carnaval (Opcional, mas comum)
        if (dia == pascoa.AddDays(-47)) return true; // Terça de Carnaval
        if (dia == pascoa.AddDays(-2)) return true;  // Sexta-feira Santa
        if (dia == pascoa.AddDays(60)) return true;  // Corpus Christi

        return false;
    }

    private static DateTime CalcularPascoa(int ano)
    {
        int a = ano % 19;
        int b = ano / 100;
        int c = ano % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;

        int mes = (h + l - 7 * m + 114) / 31;
        int dia = ((h + l - 7 * m + 114) % 31) + 1;

        return new DateTime(ano, mes, dia);
    }
}