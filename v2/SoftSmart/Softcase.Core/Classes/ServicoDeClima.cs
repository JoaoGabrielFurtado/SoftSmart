using Newtonsoft.Json;

namespace Softcase.Core.Classes;

public class ServicoDeClima
{
    private const string key = "6c808a1d47d9ea2c1927bf79cbce3dd1";
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
