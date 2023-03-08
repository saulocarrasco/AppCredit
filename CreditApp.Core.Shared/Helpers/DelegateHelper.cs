namespace CreditApp.Shared.Services.Common.Helpers
{
    public class DelegateHelper
    {
        public static Func<string, DateTimeOffset> DateHandler = (string x) =>
            !string.IsNullOrEmpty(x) ? DateTimeOffset.Parse(x) : default;
    }
}
