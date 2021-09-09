﻿using System.Windows.Automation;

namespace UIAutomationTaskSolution
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UserProfile user = new UserProfile();
            user.Login = "Egor@email.com";
            user.Password = "12";

            AutomationElement autElement =
                AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.NameProperty, "MainWindow"));

            AutomationElement buttonControl = autElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, "Log In"));

            ClickOnButton(buttonControl);

            autElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ClassNameProperty, "#32770"));

            AutomationElement textFieldControl = autElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "1003"));

            SetText(textFieldControl, user.Login);

            textFieldControl = autElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "1005"));

            SetText(textFieldControl, user.Password);

            buttonControl = autElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, "ОК"));

            ClickOnButton(buttonControl);
        }

        public static void SetText(AutomationElement textField, string text) // заполнение полей
        {
            ValuePattern vp = textField.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (vp != null) vp.SetValue(text);
        }

        public static void ClickOnButton(AutomationElement button) // нажатие на кнопку
        {
            InvokePattern clickOnButton = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (clickOnButton != null) clickOnButton.Invoke();
        }
    }
}