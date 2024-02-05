namespace MicroService.Security.Encryption.Tests.Utility;

public class ValueProvider
{
    public static string Value => "UnencryptedString";
    public static string Key => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string Salt => "0123456789";
}
