using System.Windows.Automation;

namespace SharpE2e.Core.Utilities
{
    public static class WaitHelper
    {
        public static AutomationElement WaitUntilElementExists(Func<AutomationElement> finder, int timeoutSeconds = 5)
        {
            AutomationElement result = null;
            int waited = 0;

            while (result == null && waited < timeoutSeconds * 10)
            {
                result = finder();
                if (result == null)
                {
                    Thread.Sleep(100); // 100ms Intervalle
                    waited++;
                }
            }

            return result ?? throw new TimeoutException("Element nicht gefunden.");
        }
    }
}
