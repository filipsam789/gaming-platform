namespace GamingPlatform.Domain.SportEventDomain.Enum;

public class EnumHelper
{
    public static List<string> GetEnumValues<T>() where T : System.Enum
    {
        return System.Enum.GetValues(typeof(T)).Cast<T>().Select(e => e.ToString()).ToList();
    }
}