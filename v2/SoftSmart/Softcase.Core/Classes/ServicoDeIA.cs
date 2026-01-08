using Microsoft.ML;
using Softcase_ML; 

namespace Softcase.Core.Classes
{
    public static class ServicoDeIA
    {
        public static int RetornaResultadoIA(float horario, float diaSemana, float temperatura, float estaChovendo, float temEvento, float ehFeriado)
        {
            var mlContext = new MLContext();

            string pastaDoExecutavel = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoCompleto = Path.Combine(pastaDoExecutavel, "ModeloOcupacao.mlnet");

            ITransformer mlModel = mlContext.Model.Load(caminhoCompleto, out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModeloOcupacao.ModelInput, ModeloOcupacao.ModelOutput>(mlModel);

            var dadosEntrada = new ModeloOcupacao.ModelInput
            {
                Hora = horario,
                DiaDaSemana = diaSemana,
                Temperatura = temperatura,
                Chuva = estaChovendo,
                EventoNaRegiao = temEvento,
                EhFeriado = ehFeriado
            };

            var resultado = predEngine.Predict(dadosEntrada);

            return (int)resultado.Score;
        }
    }
}