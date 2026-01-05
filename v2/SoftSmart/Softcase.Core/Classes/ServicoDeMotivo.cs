using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcase.Core.Classes;

public class ServicoDeMotivo
{
        public static string GerarMotivo(int manha, int tarde, int noite, string temEvento, string temChuva, float temperatura)
        {
            if (temEvento == "Sim")
                return "💡 ALERTA: Ocupação crítica prevista devido a evento na região.";

            //temperatura
            if (temChuva == "Sim" && temperatura < 20)
                return "🌧 Chuva e frio podem reduzir o fluxo de rotatividade em áreas descobertas.";

            if (temperatura > 32)
                return "☀ Calor intenso previsto. Alta procura esperada por vagas cobertas/sombreadas.";

            // horários 
            if (noite > 85 && manha < 30)
                return "📈 Tendência de alta noturna. O movimento será concentrado no happy hour/jantar.";

            if (manha > 70 && tarde > 70 && noite > 70)
                return "🔥 Dia de alta demanda constante. Não haverá janelas de baixa ocupação.";

            if (manha < 20 && tarde < 20 && noite < 20)
                return "📉 Dia atípico com baixa ocupação geral. Bom momento para manutenções.";

            // 4. Default
            return "✅ Operação dentro da normalidade para o dia da semana.";
        }
}
