namespace Lab.UI.Utility
{
    public interface IMessageService
    {
        MessageDialogResult ShowOkCancelDialog(string text, string title);
        MessageDialogResult ShowOkDialog(string text, string title);
    }
}