namespace Softcase.Core.DTOs;

public class PrevisaoFutura
{
    public DateTime Data { get; set; }
    public float Temperatura { get; set; }

    public float Chuva { get; set; }

    public float EhFeriado { get; set; }

    public float TempManha { get; set; }
    public float TempTarde { get; set; }
    public float TempNoite { get; set; }
}
