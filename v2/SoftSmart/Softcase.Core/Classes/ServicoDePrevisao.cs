using Softcase.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcase.Core.Classes;

public class ServicoDePrevisao
{

    private ServicoDeClima servicoDeClima = new();

    public async Task<List<PrevisaoFutura>> RetornaPrevisaoFuturaAsync(string cidade, int prever)
    {
        cidade = cidade + ", BR";
        List<PrevisaoFutura> listaPrevisaoFutura = new();
        RespostaClima retorno = await servicoDeClima.VerificaClimaAsync(cidade);

        if (retorno == null || retorno.list == null) return listaPrevisaoFutura;

        for (int i = 1; i <= prever; i++)
        {
            DateTime dataAlvo = DateTime.Now.Date.AddDays(i);

            var registrosDoDia = retorno.list.Where(x => Convert.ToDateTime(x.dt_txt).Date == dataAlvo).ToList();

            if (registrosDoDia.Any())
            {
                var principal = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 12) ?? registrosDoDia.First();


                var itemManha = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 9) ?? registrosDoDia.First();

                var itemTarde = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 15) ?? principal;

                var itemNoite = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 21) ?? registrosDoDia.Last();


                float indicadorChuva = 0;
                if (principal.weather != null && principal.weather.Length > 0)
                {
                    string condicao = principal.weather[0].main;
                    if (condicao == "Rain" || condicao == "Thunderstorm" || condicao == "Drizzle")
                        indicadorChuva = 1;
                }

                bool feriado = ServicoDeCalendario.EhFeriado(dataAlvo);

                PrevisaoFutura p = new PrevisaoFutura
                {
                    Data = dataAlvo,
                    Temperatura = (float)Math.Round(principal.main.temp),
                    Chuva = indicadorChuva,
                    EhFeriado = feriado ? 1 : 0,


                    TempManha = (float)Math.Round(itemManha.main.temp),
                    TempTarde = (float)Math.Round(itemTarde.main.temp),
                    TempNoite = (float)Math.Round(itemNoite.main.temp)
                };
                listaPrevisaoFutura.Add(p);
            }
        }
        return listaPrevisaoFutura;
    }
}
