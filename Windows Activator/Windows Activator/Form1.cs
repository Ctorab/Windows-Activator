using System.Diagnostics;
using HtmlAgilityPack;
using Microsoft.Win32;

namespace Windows_Activator
{
    public partial class Form1 : Form
    {
        private const int KEY_LENGTH = 29;
        private string? _key = null;

        public Form1() => InitializeComponent();

        private void ActivateBtn_Click(object sender, EventArgs e) => ActivateWindows();

        private void ActivateWindows()
        {
            GetActivationKey(out _key);
            RunCMD(_key);
        }

        private void GetActivationKey(out string? key)
        {
            var winVersion = WindowsVersion();

            if (winVersion == null)
            {
                key = null;
                return;
            }

            var link = @"https://docs.microsoft.com/en-us/windows-server/get-started/kms-client-activation-keys";

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(link);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//body").InnerText.Replace('\t', '\0');

            int i = node.IndexOf(winVersion) + winVersion.Length;
            key = node.Substring(i + 1, KEY_LENGTH);

            WindowsKeyLabel.Text = key;
        }

        private void RunCMD(string? key)
        {
            if (key == null) return;

            string runCommand = $"/C slmgr/ipk {key} \n slmgr / skms kms.digiboy.ir \n slmgr / ato";

            ProcessStartInfo myProcessInfo = new ProcessStartInfo();
            myProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            myProcessInfo.Arguments = runCommand;
            myProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcessInfo.UseShellExecute = true;
            myProcessInfo.Verb = "runas";

            Process.Start(myProcessInfo);
        }

        private string? WindowsVersion()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string? osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "")?.ToString();

            return osName;
        }
    }
}