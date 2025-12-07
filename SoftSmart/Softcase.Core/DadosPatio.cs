namespace Softcase.Core
{
    public class DadosPatio
    {


        //OBS: declarei todas as props como float pois o ML entende melhor. 

        // Entradas 
        public float Hora { get; set; }           
        public float DiaDaSemana { get; set; }    
        public float Temperatura { get; set; }    
        public float Chuva { get; set; }          
        public float EventoNaRegiao { get; set; } 
        public float EhFeriado { get; set; }
        public DadosPatio(float hora, float diaDaSemana, float temperatura, float chuva, float eventoNaRegiao, float ehFeriado, float ocupacao)
        {
            Hora = hora;
            DiaDaSemana = diaDaSemana;
            Temperatura = temperatura;
            Chuva = chuva;
            EventoNaRegiao = eventoNaRegiao;
            EhFeriado = ehFeriado;
            Ocupacao = ocupacao;
        }
        // Saída 
        public float Ocupacao { get; set; }       
    }
}
