namespace MicroService.Components.Tests.Utility;

public class GlobalValueProvider
{
    public static int RandomInt(int minValue = default, int maxValue = int.MaxValue) => new Random().Next(minValue, maxValue);
    public static Guid RandomGuid() => Guid.NewGuid();
    public static string RandomGuidString() => RandomGuid().ToString();
    public static double RandomDouble(double minValue = default, double maxValue = double.MaxValue) => new Random().NextDouble() * (maxValue - minValue) + minValue;
    public static decimal RandomDecimal(double minValue = default, double maxValue = double.MaxValue) => new(new Random().NextDouble() * (maxValue - minValue) + minValue);
    public static long RandomLong(long minValue = default, long maxValue = long.MaxValue) => new Random().NextInt64(minValue, maxValue);
    public static bool RandomBool() => new Random().Next(0, 2) != 0;
    public static DateTime RandomDateTime(int minYearOffset, int maxYearOffset = 0)
    {
        var random = new Random();

        var minYear = DateTime.Today.AddYears(minYearOffset).Year;
        var maxYear = DateTime.Today.AddYears(maxYearOffset).Year;

        var result = new DateTime(random.Next(minYear, maxYear + 1), random.Next(1, 13), random.Next(1, 29));

        return result <= DateTime.Today
            ? result
            : DateTime.Today;
    }
    public static DateTime RandomDateTime(DateTime startDate, DateTime? endDate = null)
    {
        endDate ??= DateTime.Today;

        var range = (endDate.Value - startDate).Days;
        if (range < 2) return DateTime.Today;

        var offset = new Random().Next(1, range);
        var result = startDate.AddDays(offset);

        return result <= DateTime.Today
            ? result
            : DateTime.Today;
    }
    public static long RandomPhoneNumber(bool isMobile = false)
    {
        var random = new Random();
        var areaPart = isMobile
            ? 7
            : random.Next(1, 3);

        var digitsPart = random.Next(100000000, 999999999);

        return long.Parse($"0{areaPart}{digitsPart}");
    }
    public static string RandomEmailAddress()
    {
        return $"{Guid.NewGuid}@example.com";
    }
}
