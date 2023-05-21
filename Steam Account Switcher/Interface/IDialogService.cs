using System.Windows.Forms;

namespace Steam_Account_Switcher
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        DialogResult ShowMessage(string text, string caption, MessageBoxButtons buttons);
        DialogResult ShowMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
    }
}
