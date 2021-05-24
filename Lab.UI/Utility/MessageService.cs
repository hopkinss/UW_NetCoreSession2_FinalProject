using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Lab.UI.Utility
{
    public class MessageService : IMessageService
    {
        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            var response = MessageBox.Show(text, title, MessageBoxButton.OKCancel);

            return response == MessageBoxResult.OK ? MessageDialogResult.OK : MessageDialogResult.Cancel;
        }
    }

    public enum MessageDialogResult { OK,Cancel}
}
