using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcase.Core.DTOs;

public class ResultadoConsolidado
{
    public DateTime Data { get; set; }
    public float Temperatura { get; set; }
    public int OcupacaoPrevista { get; set; }
    public string MotivoPrincipal { get; set; } 
}
