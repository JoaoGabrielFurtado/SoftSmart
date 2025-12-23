using Nager.Date;
namespace Softcase.Core;
public static class ServicoDeCalendario
{
    public static bool EhFeriado(DateTime data)
    {
        return HolidaySystem.IsPublicHoliday(data.Date, CountryCode.BR);
    }
}
