// TODO-IG: Add Intentionally Bad Code warning!
using System;
using System.Linq;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using Pragmatic.Interaction;

namespace Pragmatic.Example.Client.Desktop
{
    static class UserInteraction
    {
        internal static void ShowError(string message, Response response)
        {
            ModernDialog.ShowMessage(string.Format("{1}{0}{2}",
                                Environment.NewLine,
                                message,
                                response.Errors.Aggregate(string.Empty,
                                    (result, error) => string.Format("{1}{2}{0}", Environment.NewLine, result, error.Message))),
                             "Error",
                             MessageBoxButton.OK);
        }

        internal static void ShowInformation(string message)
        {
            ModernDialog.ShowMessage(message,
                            "Information",
                            MessageBoxButton.OK);
        }

        internal static MessageBoxResult ShowQuestion(string message, MessageBoxButton messageBoxButton)
        {
            return ModernDialog.ShowMessage(message,
                                   "Question",
                                   messageBoxButton);
        }

        internal static MessageBoxResult ShowResponse(string message, Response response, MessageBoxButton messageBoxButton)
        {
            var caption = "Information";

            if (response.HasErrors)
            {
                caption = "Error";
            }
            else if (response.HasWarnings)
            {
                caption = "Warning";
            }
            else if (response.HasInformation)
            {
                caption = "Information";
            }

            var responseMessage = (response.Errors.Aggregate(string.Empty, (result, error) => string.Format("{1}{2}{0}", Environment.NewLine, result, error.Message)) + Environment.NewLine +
                                      response.Warnings.Aggregate(string.Empty, (result, error) => string.Format("{1}{2}{0}", Environment.NewLine, result, error.Message)) + Environment.NewLine +
                                      response.Information.Aggregate(string.Empty, (result, error) => string.Format("{1}{2}{0}", Environment.NewLine, result, error.Message))).Trim();

            return ModernDialog.ShowMessage((message + Environment.NewLine + responseMessage).Trim(), caption, messageBoxButton);
        }
    }
}
