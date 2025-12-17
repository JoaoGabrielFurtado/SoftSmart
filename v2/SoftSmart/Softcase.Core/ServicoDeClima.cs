using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Softcase.Core;

public class ServicoDeClima 
{
    private const string key = "";
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<RespostaClima> VerificaClimaAsync(string cidade)
    {
        try
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={cidade}&units=metric&lang=pt_br&appid={key}";

            var resposta = await _httpClient.GetAsync(url);

            resposta.EnsureSuccessStatusCode();

            var jsonString = await resposta.Content.ReadAsStringAsync();

            var dadosClima = JsonConvert.DeserializeObject<RespostaClima>(jsonString);

            return dadosClima;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na API: {ex.Message}");
            return null;
        }
    }
}
