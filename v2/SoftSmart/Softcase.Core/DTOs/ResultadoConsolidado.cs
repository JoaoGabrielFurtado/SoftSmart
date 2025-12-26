namespace Softcase.Core.DTOs;

public class ResultadoConsolidado
{
    public string Data { get; set; }
    public string DiaSemana { get; set; }
    public float Temperatura { get; set; }
    public int OcupacaoPrevista { get; set; }

    public string Evento { get; set; }
    public string MotivoPrincipal { get; set; }
}
