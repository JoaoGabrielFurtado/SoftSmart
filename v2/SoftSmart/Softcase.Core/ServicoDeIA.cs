using Softcase_ML;
namespace Softcase.Core;

public static class ServicoDeIA
{
    public static int RetornaResultadoIA(float horario, float diaSemana, float temperatura, float estaChovendo, float temEvento, float ehFeriado)
    {
        var dadosEntrada = new ModeloOcupacao.ModelInput
        {
            Hora = horario,
            DiaDaSemana = diaSemana,
            Temperatura = temperatura,
            Chuva = estaChovendo,
            EventoNaRegiao = temEvento,
            EhFeriado = ehFeriado
        };

        var predict = ModeloOcupacao.Predict(dadosEntrada);
        float valor = predict.Score;

        return (int)valor;
    }
}
