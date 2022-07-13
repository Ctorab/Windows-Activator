using System.Diagnostics;
using System.Net;
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

            key = null;

            if (winVersion == null) return;

            if (!CheckForInternetConnection())
            {
                MessageBox.Show("Error.You are not connected to internet.Connect to internet and try again!");
                return;
            }

            var link = @"https://docs.microsoft.com/en-us/windows-server/get-started/kms-client-activation-keys";

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(link);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//body").InnerText;

            int i = node.IndexOf(winVersion) + winVersion.Length;
            key = node.Substring(i + 1, KEY_LENGTH);

            WindowsKeyLabel.Text = key;
        }

        private void RunCMD(string? key)
        {
            if (key == null) return;

            string runCommand = $"/C slmgr/ipk {key}&slmgr /skms kms.digiboy.ir&slmgr /ato";

            ProcessStartInfo cmd = new ProcessStartInfo();
            cmd.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\cmd.exe";
            cmd.Arguments = runCommand;
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.UseShellExecute = true;
            cmd.Verb = "runas";

            Process.Start(cmd);
        }

        private string? WindowsVersion()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string? osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "")?.ToString();

            return osName;
        }

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}