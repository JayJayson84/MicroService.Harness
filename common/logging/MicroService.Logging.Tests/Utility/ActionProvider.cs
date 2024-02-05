namespace MicroService.Logging.Tests.Utility;

public static partial class ActionProvider
{

    public static Action ThrowExceptionFor(string message, Action<Exception> action)
    {
        return () =>
        {
            try
            {
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                action(ex);
                throw;
            }
        };
    }
    
}
