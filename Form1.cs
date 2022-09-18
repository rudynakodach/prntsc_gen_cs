using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace prntsc_gen
{
	public partial class Form1 : Form
	{
		public string currentLink;

		public Form1()
		{
			InitializeComponent();
		}

		private void ButtonGenerate_Click(object sender, EventArgs e)
		{
			List<string> link = new List<string>();
			List<string> Characters = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "y", "v", "x", "w", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
			Random random = new Random();

			for(int i = 0; i < 6; i++)
			{
				int x = random.Next(0, Characters.Count);

                link.Add(Characters[x].ToString());
			}

			currentLink = String.Join("", link);

			LinkTextLabel.Text = $"https://prnt.sc/{currentLink}";
			
			
			if(CheckBoxLog.Checked)
            {
				string currentDirectory = Directory.GetCurrentDirectory();
				string saveFileName = "/log.txt";
				

				if(File.Exists(currentDirectory + saveFileName))
                {
					FileStream fs = new FileStream(currentDirectory + saveFileName, FileMode.Open);
                    try
                    {
						
                    }
					
					catch(IOException)
                    {
						MessageBox.Show("IOException erorr!", "Error!");
                    }
					catch(UnauthorizedAccessException)
                    {
						MessageBox.Show("UnathorizedAccessException erorr!", "Error!");
                    }
                }
				
            }
			
			
		}

		private void LinkTextLabel_Click(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
            if(currentLink != String.Empty)
            {
                WebBrowser.OpenUrl($"https://prnt.sc/{currentLink}");
            }
			
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
    public static class WebBrowser
    {
        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }

            }
        }
    }

    public static class Logger
    {
        public static void Log(string Message, string FilePath)
        {
            if(File.Exists(FilePath))
            {

            }
            else if(!File.Exists(FilePath))
            {
                return;
            }
        }
    }
}
