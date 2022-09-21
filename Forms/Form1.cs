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

		public int linksGenerated = 0;

		public string currentLink;
		public string currentDirectory = Directory.GetCurrentDirectory();
		public const string saveFileName = "/log.txt";

		readonly List<string> link = new List<string>();
		readonly List<string> Characters = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "y", "v", "x", "w", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
		readonly Random random = new Random();

		public Form1()
		{
			InitializeComponent();
		}

		private void ButtonGenerate_Click(object sender, EventArgs e)
		{
			linksGenerated++;
			LinksGeneratedLabel.Text = $"Links Generated: {linksGenerated}";
			//clear the list if it contains anything
			if (link.Count != 0)
			{
				link.Clear();
			}
			for (int i = 0; i < 6; i++)
			{
				int x = random.Next(0, Characters.Count);

				link.Add(Characters[x].ToString());
			}

			currentLink = "https://www.prnt.sc/" + String.Join("", link);

			CurrentLinkLabel.Text = $"{currentLink}";

			if (CheckBoxLog.Checked)
			{
				string saveDir = currentDirectory + saveFileName;

				Logger.Log(DateTime.Now.ToString("HH:mm:ss tt",System.Globalization.DateTimeFormatInfo.InvariantInfo) , saveDir, AppStatusLabel, currentLink);
			}
			if(AutoPreviewCheckbox.Checked)
            {
				webBrowser1.Url = new Uri(currentLink);
            }
		}

		private void LinkTextLabel_Click(object sender, EventArgs e) { }

		private void button1_Click(object sender, EventArgs e)
		{
			if (currentLink != String.Empty)
			{
				WebBrowser.OpenInBrowser(currentLink);
			}
		}

		private void AppStatusLabel_Click(object sender, EventArgs e) { }

		private void Form1_Load(object sender, EventArgs e) 
		{
			Logger.OnStartupMessage(currentDirectory + saveFileName);

			if(!File.Exists(currentDirectory + saveFileName))
			{
				AppStatusLabel.Text = "Save File Not Found! Creating one...";
				try { File.Create(currentDirectory + saveFileName); }
				
				catch (Exception sfc)
				{
					AppStatusLabel.Text = sfc.Message;
				}
			}
			else
			{
				AppStatusLabel.Text = "Ready.";
			}
		}

		private void OpenLogButton_Click(object sender, EventArgs e)
		{
			Logger.OpenLogFile(currentDirectory + saveFileName);
		}

		public static class WebBrowser
		{
			public static void OpenInBrowser(string url)
			{
				if(String.IsNullOrWhiteSpace(url)) { return; }
				try
				{
					Process.Start(url);
				}
				catch
				{
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

		public class Logger : Form1
		{
			public static void Log(string Message, string FilePath, Label textLabel, string currentLink)
			{
				try
				{
					StreamWriter sw = new StreamWriter(FilePath, true);

					string timeNow = DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);

					sw.WriteLine($"{Message}");
					textLabel.Text = $"[{timeNow}] Saved!";
					sw.Close();
				}
				catch (Exception e)
				{
					textLabel.Text = e.Message;
				}
			}
		
			public static void OpenLogFile(string FilePath)
			{
				if (File.Exists(FilePath))
				{
					System.Diagnostics.Process.Start(FilePath);
				}
			}


			public static void OnStartupMessage(string FilePath)
			{
				if (File.Exists(FilePath))
				{
					StreamWriter sw = new StreamWriter(FilePath, true, Encoding.UTF8);

					sw.WriteLine($"\n----------| APP LAUNCHED {DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)} |----------");
					sw.WriteLine($"Currently in {Directory.GetCurrentDirectory()}");

					sw.Close();
				}
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if(SaveMessageTextBox.Text.ToString() == string.Empty)
				Logger.Log($"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] Link Saved Manually | {currentLink}", currentDirectory + saveFileName, AppStatusLabel, currentLink);
			else if (SaveMessageTextBox.Text.ToString() != string.Empty)
			{
				string customMessage = SaveMessageTextBox.Text;
				Logger.Log($"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] {customMessage} | {currentLink}", currentDirectory + saveFileName, AppStatusLabel, currentLink);
			}
		}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
			if(File.Exists(currentDirectory + saveFileName))
            {
				StreamWriter sw = new StreamWriter(currentDirectory + saveFileName, true, Encoding.UTF8);
                {
					sw.WriteLine($"Session Ended.\n----------| APP CLOSED {DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)} |----------");

					sw.Close();
                }
            }
        }
        private void PreviewLinkButton_Click(object sender, EventArgs e)
		{
			try
			{
				webBrowser1.Url = new Uri(currentLink);
			}
			catch ( Exception plbE )
            {
				AppStatusLabel.Text = plbE.Message;
            }
		}

        private void ClearLogsButton_Click(object sender, EventArgs e)
        {
			string timeNow = DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
			StreamWriter sw = new StreamWriter(currentDirectory + saveFileName, false);
			sw.WriteLine("" +
				"\n##############################" +
				$"\n## LOGS CLEARED {timeNow} ##" +
				"\n##############################\n");
			sw.Close();
        }
    }
}
