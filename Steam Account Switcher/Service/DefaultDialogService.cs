using System.Windows.Forms;

namespace Steam_Account_Switcher
{
    public class DefaultDialogService : IDialogService
    {
        public void ShowMessage(string message) => MessageBox.Show(message);

        public void ShowMessage(string text, string caption, MessageBoxButtons buttons) => MessageBox.Show(text, caption, buttons);

        public DialogResult ShowMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton) => MessageBox.Show(text, caption, buttons, icon, defaultButton);

        DialogResult IDialogService.ShowMessage(string text, string caption, MessageBoxButtons buttons) => MessageBox.Show(text, caption, buttons);
    }
}
