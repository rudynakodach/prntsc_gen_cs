using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Linq;

/*	---------------------
 *	|	 prnt_sc_gen	|
 *	|	   Form1.cs		|
 *	|	using WinForms	|
 *	|	 SP 35 8D nr 5	|
 *	---------------------*/

namespace prntsc_gen
{
    public partial class Form1 : Form
    {
        /*----------------------
		 *| 				   |
		 *|Deklaracja zmiennych|
		 *|					   |
		 *----------------------*/
        public int linksGenerated = 0;

        public string currentLink;
        public string currentDirectory = Directory.GetCurrentDirectory();
        public const string saveFileName = "/log.txt";

        readonly List<string> link = new List<string>();
        readonly List<string> Characters = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "y", "v", "x", "w", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        readonly Random random = new Random();

        //Konstruktor klasy
        public Form1()
        {
            InitializeComponent();
        }


        //funkcja wywoływana przy naciśnięciu przycisku "Generate"
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
                link.Add(Characters[random.Next(0, Characters.Count - 1)].ToString());
            }

            if (link[0] == "0")
            {
                link[0] = Characters[random.Next(0, Characters.Count - 1)];
            }

            currentLink = "http://www.prnt.sc/" + String.Join("", link);

            CurrentLinkLabel.Text = $"{currentLink}";

            if (!WebBrowser.Get(WebBrowser.GetDirectImageLink(htmlLabel, new Uri(currentLink)), AppStatusLabel))
            {
                AppStatusLabel.Text = $"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] HttpResponse Failed!";
                ButtonGenerate_Click(sender, e);
            }

            if (CheckBoxLog.Checked)
            {
                string saveDir = currentDirectory + saveFileName;

                Logger.Log(DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo), saveDir, AppStatusLabel);
            }

            if (AutoPreviewCheckbox.Checked)
            {
                Uri currentLinkUri = new Uri(currentLink);

                string directImageLink = WebBrowser.GetDirectImageLink(htmlLabel, currentLinkUri);

                if(string.IsNullOrWhiteSpace(directImageLink))
                {
                    ButtonGenerate_Click(sender, e);
                    return;
                }
                else
                {
                    webBrowser1.Url = new Uri(WebBrowser.GetDirectImageLink(htmlLabel, currentLinkUri));
                }
            }
        }

        private void OpenInBrowserButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(currentLink))
            {
                WebBrowser.OpenInBrowser(currentLink);
            }
        }

        //funkcja wywoływana przy załadowaniu okna
        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.OnStartupMessage(currentDirectory + saveFileName);

            if (!File.Exists(currentDirectory + saveFileName))
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
            /* Odwołanie do klasy Logger, funkcji 'OpenLogFile' */

            Logger.OpenLogFile(currentDirectory + saveFileName);
        }


        /* Deklaracja Klasy 'WebBrowser' */
        public static class WebBrowser
        {
            public static void OpenInBrowser(string url)
            {
                /* Jeśli obecny link jest pusty, wyjdź z funkcji*/
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


            /* Funkcja zwracająca liczbe całkowitą reprezentującą kod statusu odpowiedzi serwera */
            /*
				200 - OK 
				404 - Not Found
				403 - Forbidden
				etc.
			 */
            public static bool Get(string url, Label AppStatusLabel)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 5000; //po 5000 ms, rozłącz i zwróć błąd
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36"; //"podszywani" się pod normalnego klienta; zapobiega błędowi 403

                bool success = true;

                try
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            success = true;
                        }
                    }
                }
                catch (Exception getE)
                {
                    AppStatusLabel.Text = getE.Message;
                    success = false;
                }

                request.Abort();
                return success;
            }

            //Workflow: pobierz html strony -> zostawić tylko tekst w cudzyslowach -> zwrócić link z listy
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
                    if (goodQuotes.Contains(str)) { continue; } //nie dodawaj tych samych linków
                    if (str.Contains("/") && str.Contains("image.prntscr") && !str.Contains("google") || !str.Contains("google") && str.Contains("/") && str.Contains("imgur")) { goodQuotes.Add(str); continue; }
                }

                htmlLabel.Text = $"Len: {goodQuotes.Count}, AllLen: {html_quotes.Count} | {String.Join("", goodQuotes)} AllHtmlQuotes: {string.Join("", html_quotes)}";
                try
                {
                    return goodQuotes.First();
                }
                catch
                {
                    return null;
                }

            }

            //konwertuje zawartośc html na liste tekstu która jest w cudzysłowach
            public static List<string> HtmlGetEveryObjectInQuotes(char[] htmlChars)
            {
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
                        link += ch; //dodaj znaki do string po cudzysłowiu
                    }
                }
                return links;
            }
        }

        public class Logger : Form1
        {
            public static void Log(string Message, string FilePath, Label textLabel)
            {
                if (string.IsNullOrWhiteSpace(Message))
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
            if (SaveMessageTextBox.Text.ToString() == string.Empty)
                Logger.Log($"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] Link Saved Manually | {currentLink}", currentDirectory + saveFileName, AppStatusLabel);
            else if (!string.IsNullOrWhiteSpace(SaveMessageTextBox.Text))
            {
                string customMessage = SaveMessageTextBox.Text;
                Logger.Log($"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] {customMessage} | {currentLink}", currentDirectory + saveFileName, AppStatusLabel);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(currentDirectory + saveFileName))
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
                webBrowser1.Url = new Uri(WebBrowser.GetDirectImageLink(htmlLabel, new Uri(currentLink)));
            }
            catch (Exception plbE)
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
            AppStatusLabel.Text = $"[{DateTime.Now.ToString("HH:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)}] Link saved to clipboard!";
        }

        private void GetDirectImageLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(WebBrowser.GetDirectImageLink(htmlLabel, new Uri(currentLink)));
        }
    }
}
