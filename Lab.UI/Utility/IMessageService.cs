namespace Lab.UI.Utility
{
    public interface IMessageService
    {
        MessageDialogResult ShowOkCancelDialog(string text, string title);
    }
}