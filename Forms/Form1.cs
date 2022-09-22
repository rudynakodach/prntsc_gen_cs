using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace prntsc_gen
{
	public partial class Form1 : Form
	{
		public static WebClient wc = new WebClient();

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
			if (link.Count > 0)
			{
				link.Clear();
			}
			for (int i = 0; i < 6; i++)
			{
				int x = random.Next(0, Characters.Count - 1);

				link.Add(Characters[x].ToString());
			}

			if (link[0] == "0")
			{
				link[0] = Characters[random.Next(0, Characters.Count - 1)];
			}

			currentLink = "http://www.prnt.sc/" + String.Join("", link);

			CurrentLinkLabel.Text = $"{currentLink}";

            AppStatusLabel.Text = $"{DateTime.Now.ToString("HH:mm:ss tt",System.Globalization.DateTimeFormatInfo.InvariantInfo)} HttpResponse: {WebBrowser.Get(currentLink)}";


            if (WebBrowser.Get(currentLink) != 200)
			{
				return;
			}

			if (CheckBoxLog.Checked)
			{
				string saveDir = currentDirectory + saveFileName;

				Logger.Log(DateTime.Now.ToString("HH:mm:ss tt",System.Globalization.DateTimeFormatInfo.InvariantInfo) , saveDir, AppStatusLabel);
			}
			if(AutoPreviewCheckbox.Checked)
			{
				Uri currentLinkUri = new Uri(currentLink);
				webBrowser1.Url = new Uri(WebBrowser.GetDirectImageLink(htmlLabel, currentLinkUri));
			}
		}

		private void LinkTextLabel_Click(object sender, EventArgs e) { }

		private void OpenInBrowserButton_Click(object sender, EventArgs e)
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
				if (string.IsNullOrWhiteSpace(url)) { return; }
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

			public static int Get(string url)
			{
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
				request.Timeout = 5000;
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode status = response.StatusCode;

				request.Abort();

				return (int)status;
            }

			public static string GetDirectImageLink(Label htmlLabel, Uri url)
			{
				WebClient wc = new WebClient();
				wc.Headers.Add("user-agent", "prntsc_gen");

				byte[] htmlContent = wc.DownloadData(url);

				char[] htmlChars = Encoding.Default.GetString(htmlContent).ToCharArray();

				List<string> html_quotes = HtmlGetEveryObjectInQuotes(htmlChars);
				List<string> goodQuotes = new List<string>();
				
				foreach (string str in html_quotes)
				{
					if(str.Contains("/") && str.Contains("image.prntscr") && !str.Contains("google") || !str.Contains("google") && str.Contains("/") && str.Contains("imgur")) { goodQuotes.Add(str); continue; }
				}

				htmlLabel.Text = $"Len: {goodQuotes.Count}, AllLen: {html_quotes.Count} | {String.Join("", goodQuotes)}";
				return goodQuotes.First();
			}

            //creds to 0xC0LD
            public static List<string> HtmlGetEveryObjectInQuotes(char[] htmlChars)
			{
				//get urls like this: blablablablablablabla "some url we want" blablablablabla
				List<string> links = new List<string>();
				string link = "";
				bool afterQuote = false;
				foreach (char ch in htmlChars)
				{
					if (ch == '"')
					{
						afterQuote = !afterQuote;

						if (!afterQuote)
						{
							links.Add(link);
							link = "";
						}
					}
					else if (afterQuote)
					{
						link += ch; //add chars to string after quote
					}
				}
				return links;
			}
		}

		public class Logger : Form1
		{
			public static void Log(string Message, string FilePath, Label textLabel)
			{
				if(string.IsNullOrWhiteSpace(Message))
				{
					return;
				}

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
				Logger.Log($"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] Link Saved Manually | {currentLink}", currentDirectory + saveFileName, AppStatusLabel);
			else if (!string.IsNullOrWhiteSpace(SaveMessageTextBox.Text))
			{
				string customMessage = SaveMessageTextBox.Text;
				Logger.Log($"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] {customMessage} | {currentLink}", currentDirectory + saveFileName, AppStatusLabel);
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
			sw.WriteLine(
				"\n##############################" +
				$"\n## LOGS CLEARED {timeNow} ##" +
				"\n##############################\n");
			sw.Close();
		}

		private void testbutton_Click(object sender, EventArgs e)
		{
			try
			{
                WebBrowser.GetDirectImageLink(htmlLabel, new Uri(currentLink));

            }
			catch (Exception wbtE)
			{
				AppStatusLabel.Text = wbtE.Message;
			}
        }

		private void CopyLinkToClipboardButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(currentLink);
			AppStatusLabel.Text = $"[{DateTime.Now.ToString("HH:mm:ss tt",System.Globalization.DateTimeFormatInfo.InvariantInfo)}] Link saved to clipboard!";
		}
	}
}
