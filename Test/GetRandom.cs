namespace Abc.Aids;

public static class GetRandom
{
    private static readonly Random Random = new();

    public static int Int32() => Random.Next(1, int.MaxValue);

    public static decimal Decimal() => (decimal)(Random.NextDouble() * 1000d + 1d);

    public static string String() => Guid.NewGuid().ToString("N");

    public static DateTime DateTime() => System.DateTime.UtcNow.AddMinutes(Random.Next(-100000, 100000));
}
