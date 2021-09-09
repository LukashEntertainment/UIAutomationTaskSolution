using System.Windows.Automation;

namespace UIAutomationTaskSolution
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UserProfile user = new UserProfile();
            user.Login = "Egor@email.com";
            user.Password = "!QAZ";
            
            AutomationElement autElement =
                AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "MainWindow"));

            AutomationElement buttonControl = autElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, "Log In"));

            InvokePattern clickOnButton = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            
            if (clickOnButton != null)
            {
                clickOnButton.Invoke();

                autElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.ClassNameProperty, "#32770"));

                AutomationElement textFieldControl = autElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "1003"));

                ValuePattern vp = textFieldControl.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                vp.SetValue(user.Login);

                textFieldControl = autElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "1005"));
                
                vp = textFieldControl.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                vp.SetValue(user.Password);

                buttonControl = autElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "ОК"));
                clickOnButton = buttonControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                clickOnButton.Invoke();
            }
        }
    }
}