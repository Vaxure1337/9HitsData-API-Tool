using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace _9HitsData
{
    public class API
    {
        #region ViewerDownload
        public void DownloadHitsViewerWinX64()
        {
            try
            {
                if (!Directory.Exists("bin"))
                    Directory.CreateDirectory("bin");
                if (!Directory.Exists("bin\\9hviewer"))
                    Directory.CreateDirectory("bin\\9hviewer");
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadFile("http://f.9hits.com/9hviewer/9hviewer-win-x64.zip", "bin\\9hviewer\\9hviewer-win-x64.zip");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }

        public void DownloadHitsViewerWinX86()
        {
            try
            {
                if (!Directory.Exists("bin"))
                    Directory.CreateDirectory("bin");
                if (!Directory.Exists("bin\\9hviewer"))
                    Directory.CreateDirectory("bin\\9hviewer");
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadFile("http://f.9hits.com/9hviewer/9hviewer-win-x86.zip", "bin\\9hviewer\\9hviewer-win-x86.zip");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }

        public void DownloadHitsViewerLinux()
        {
            try
            {
                if (!Directory.Exists("bin"))
                    Directory.CreateDirectory("bin");
                if (!Directory.Exists("bin\\9hviewer"))
                    Directory.CreateDirectory("bin\\9hviewer");
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadFile("http://f.9hits.com/9hviewer/9hviewer-linux-x64.tar.bz2", "bin\\9hviewer\\9hviewer-linux-x64.tar.bz2");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }
        #endregion ViewerDownload
        #region BotDownload
        public void DownloadHitsBotWinX64()
        {
            try
            {
                if (!Directory.Exists("bin"))
                    Directory.CreateDirectory("bin");
                if (!Directory.Exists("bin\\9hbot"))
                    Directory.CreateDirectory("bin\\9hbot");
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadFile("http://f.9hits.com/9hbot/9hbot-win-x64.zip", "bin\\9hbot\\9hbot-win-x64.zip");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }

        public void DownloadHitsBotWinX86()
        {
            try
            {
                if (!Directory.Exists("bin"))
                    Directory.CreateDirectory("bin");
                if (!Directory.Exists("bin\\9hbot"))
                    Directory.CreateDirectory("bin\\9hbot");
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadFile("http://f.9hits.com/9hbot/9hbot-win-x86.zip", "bin\\9hbot\\9hbot-win-x86.zip");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }

        public void DownloadHitsBotLinuxX64()
        {
            try
            {
                if (!Directory.Exists("bin"))
                    Directory.CreateDirectory("bin");
                if (!Directory.Exists("bin\\9hbot"))
                    Directory.CreateDirectory("bin\\9hbot");
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadFile("http://f.9hits.com/9hbot/9hbot-linux-x64.tar.bz2", "bin\\9hbot\\9hbot-linux-x64.tar.bz2");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was an error");
            }
        }
        #endregion BotDownload
        #region Public Data

        public string LiveExchange
        {
            get
            {
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    string data = client.DownloadString("https://api.9hits.com/v2/hits_count");
                    return data.Substring(data.LastIndexOf(';') + 1);
                }
            }
        }

        public string RunningsSessions
        {
            get
            {
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    string data = client.DownloadString("https://api.9hits.com/v2/hits_count");
                    return data.Split(';')[0];
                }
            }
        }

        public string TotalUsers
        {
            get
            {
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    string data = client.DownloadString("https://9hits.com/ajax.html?type=users");
                    return new String(data.Where(char.IsDigit).ToArray());
                }
            }
        }

        public string TotalSites
        {
            get
            {
                using (var client = new WebClient())
                {
                    client.Proxy = null;
                    string data = client.DownloadString("https://9hits.com/ajax.html?type=sites");
                    return new String(data.Where(char.IsDigit).ToArray());
                }
            }
        }
        #endregion Public Data
        #region Private Data
        public string GetStatus(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                return new JavaScriptSerializer().Deserialize<Account>(json).Status;
            }
        }

        public string GetUsername(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Username;
                    default:
                        return "Error: API Key";
                }
            }
        }

        public string GetEmail(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Email;
                    default:
                        return "Error: API Key";
                }
            }
        }

        public string GetJoined(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Joined;
                    default:
                        return "Error: API Key";
                }
            }
        }

        public string GetToken(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Token;
                    default:
                        return "Error: API Key";
                }
            }
        }

        public string GetFunds(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Funds;
                    default:
                        return "Error: API Key";
                }
            }
        }

        public string GetPoints(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Points;
                    default:
                        return "Error: API Key";
                }
            }
        }

        public string GetMembership(string apikey)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;
                var json = client.DownloadString("https://panel.9hits.com/api/profileGet?key=" + apikey);
                switch (new JavaScriptSerializer().Deserialize<Account>(json).Status)
                {
                    case "ok":
                        return new JavaScriptSerializer().Deserialize<Account>(json).Data.Membership;
                    default:
                        return "Error: API Key";
                }
            }
        }
        #endregion Private Data
    }
}
