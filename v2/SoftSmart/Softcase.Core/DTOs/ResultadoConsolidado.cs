namespace Softcase.Core.DTOs;

public class ResultadoConsolidado
{
    public string Data { get; set; }      
    public string DiaSemana { get; set; } 

    public string OcupacaoManha { get; set; } // 09h
    public string OcupacaoTarde { get; set; } // 15h
    public string OcupacaoNoite { get; set; } // 21h

    public int OcupacaoManhaInt { get; set; } 
    public int OcupacaoTardeInt { get; set; } 
    public int OcupacaoNoiteInt { get; set; }

    // Média do dia 
    public int OcupacaoMedia => (OcupacaoManhaInt + OcupacaoTardeInt + OcupacaoNoiteInt) / 3;

    public float TemperaturaMedia { get; set; }
    public string Evento { get; set; } 
    public string TemChuva { get; set; }
}
