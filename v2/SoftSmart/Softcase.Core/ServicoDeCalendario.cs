using Nager.Date;

namespace Softcase.Core;

public static class ServicoDeCalendario
{
    public static bool EhFeriado(DateTime data)
    {
        // DLL Nager.Date requer uma licença para uso completo. Por enquanto não vai funcionar
        try
        {
            return HolidaySystem.IsPublicHoliday(data.Date, CountryCode.BR);
        }
        catch (LicenseKeyException)
        {
            return IsFeriadoBasicoBR(data.Date);
        }
        catch (System.Exception)
        {
            return IsFeriadoBasicoBR(data.Date);
        }
    }

    private static bool IsFeriadoBasicoBR(DateTime data)
    {
        DateTime dia = data.Date; 
        int ano = dia.Year;

        // Feriados Fixos Nacionais
        // (Janeiro)
        if (dia.Month == 1 && dia.Day == 1) return true; // Confraternização 

        // (Abril)
        if (dia.Month == 4 && dia.Day == 21) return true; // Tiradentes

        // (Maio)
        if (dia.Month == 5 && dia.Day == 1) return true; // Dia do Trabalho

        // (Setembro)
        if (dia.Month == 9 && dia.Day == 7) return true; // Independência

        // (Outubro)
        if (dia.Month == 10 && dia.Day == 12) return true; // N. Sra. Aparecida

        // (Novembro)
        if (dia.Month == 11 && dia.Day == 2) return true; // Finados
        if (dia.Month == 11 && dia.Day == 15) return true; // Proclamação da República
        if (dia.Month == 11 && dia.Day == 20) return true; // Consciência Negra 

        // (Dezembro)
        if (dia.Month == 12 && dia.Day == 25) return true; // Natal

        DateTime pascoa = CalcularPascoa(ano);

        if (dia == pascoa.AddDays(-48)) return true; // Segunda de Carnaval (Opcional, mas comum)
        if (dia == pascoa.AddDays(-47)) return true; // Terça de Carnaval
        if (dia == pascoa.AddDays(-2)) return true;  // Sexta-feira Santa
        if (dia == pascoa.AddDays(60)) return true;  // Corpus Christi

        return false;
    }

    private static DateTime CalcularPascoa(int ano)
    {
        int a = ano % 19;
        int b = ano / 100;
        int c = ano % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;

        int mes = (h + l - 7 * m + 114) / 31;
        int dia = ((h + l - 7 * m + 114) % 31) + 1;

        return new DateTime(ano, mes, dia);
    }

}
