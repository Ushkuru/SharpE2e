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

            //return new ElementWrapper(element);
        }

        public static AutomationElement FindFirstFocusedElement()
        {
            var elements = AutomationElement.FocusedElement.FindAll(TreeScope.Element, new PropertyCondition(AutomationElement.IsControlElementProperty, true));

            return elements[0];
        }

        public static ElementWrapper FindElementByAutomationId(AutomationElement parent, string automationId)
        {
            var element = parent.FindFirst(
                TreeScope.Subtree,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationId)
            );

            if (element == null)
            {
                throw new InvalidOperationException($"Element not found.");
            }

            return new ElementWrapper(element);
        }

        public static ElementWrapper FindElementByName(AutomationElement parent, string name)
        {
            var element = parent.FindFirst(
                TreeScope.Subtree,
                new PropertyCondition(AutomationElement.NameProperty, name)
            );

            if (element == null)
            {
                throw new InvalidOperationException($"Element not found.");
            }

            return new ElementWrapper(element);
        }

        public static ElementWrapper FindElementByClassName(AutomationElement parent, string name)
        {
            var element = parent.FindFirst(
                TreeScope.Subtree,
                new PropertyCondition(AutomationElement.ClassNameProperty, name)
            );

            if (element == null)
            {
                throw new InvalidOperationException($"Element not found.");
            }

            return new ElementWrapper(element);
        }

        public static IEnumerable<ElementWrapper> FindAllElementByClassName(AutomationElement parent, string className)
        {
            var condition = new PropertyCondition(AutomationElement.ClassNameProperty, className);
            var collection = parent.FindAll(TreeScope.Subtree, condition);
            for (int i = 0; i < collection.Count; i++)
            {
                yield return new ElementWrapper(collection[i]);
            }
        }
    }
}
