using Common.Contracts;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace Common.Helper
{
    public static class Utils
    {
        public static async Task<string> GetAPIResponseString(string uri)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex); 
                throw;
            }
        }

        public static async Task<string> GetAPIResponseCSV(string uri, string fileName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var contentStream = await response.Content.ReadAsStreamAsync(); // get the actual content stream
                        if (File.Exists(fileName))
                            File.Delete(fileName);
                        using (var fs = new FileStream(fileName, FileMode.CreateNew))
                        {
                            await response.Content.CopyToAsync(fs);
                        }
                        return fileName;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);                
                throw;
            }
        }

        public static string GetSubstringByString(string a, string b, string c)
        {
            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }

        #region "Logger"
        //for singleton factory thread safe lock check 
        private static readonly object Instancelock = new object();
        //create our own singleton factory instead relies on the DI since other project might not use DI container.
        private static ILogger _logger = null;
        public static ILogger Logger
        {
            get
            {
                if (_logger != null)
                    return _logger;

                lock (Instancelock)
                {
                    if (_logger == null)
                    {
                        _logger = new EventViewerLogger((int)LogLevel.Error);
                    }
                    return _logger;
                }
            }
        }
        #endregion

        #region "AppConfig" 
        public static int GetIntConfig(string configName)
        {
            int result = -1;
            string value = GetStringConfig(configName);
            if (!string.IsNullOrEmpty(value))
                int.TryParse(value, out result);
            return result;
        }

        public static string GetStringConfig(string configName, string defaultValue = "")
        {
            string result = null;

            try
            {
                result = ConfigurationManager.AppSettings.Get(configName);
            }
            catch
            {
                result = null;
            }

            return result ?? defaultValue;
        }
        #endregion

        public static string GetConnectionString(string configName, string defaultValue = "")
        {
            string result = null;

            try
            {
                result = ConfigurationManager.AppSettings.Get(configName);
            }
            catch
            {
                result = null;
            }

            return result ?? defaultValue;
        }

    }
}
