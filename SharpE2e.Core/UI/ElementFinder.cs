using System.Windows.Automation;

namespace SharpE2e.Core.UI
{
    public static class ElementFinder
    {
        public static AutomationElement FindWindowByTitle(string title)
        {
            return AutomationElement.RootElement.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.NameProperty, title)
            );
        }

        public static AutomationElement FindElementByAutomationId(AutomationElement parent, string automationId)
        {
            return parent.FindFirst(
                TreeScope.Subtree,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationId)
            );
        }
    }
}
