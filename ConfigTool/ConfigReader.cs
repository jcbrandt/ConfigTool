using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace ConfigTool
{
    class ConfigReader
    {

        public string GetAppSettingValue(string key)
        {
            try
            {
                NameValueCollection appSettings =
                     ConfigurationManager.AppSettings;

                string[] arr = appSettings.GetValues(key);
                return arr[0];
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[CreateAppSettings: {0}]",
                                  e.ToString());
                Console.WriteLine();
                return e.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("[CreateAppSettings: {0}]",
                                  e.ToString());
                Console.WriteLine();
                return e.ToString();
            }
        }

        public void CreateAppSettings(string sectionName,
                                      string key, string value)
        {
            try
            {
                Configuration config =
                 ConfigurationManager.OpenExeConfiguration
                                       (ConfigurationUserLevel.None);

                config.AppSettings.Settings.Add(key, value);
                config.Save();
                ConfigurationManager.RefreshSection(sectionName);
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[CreateAppSettings: {0}]",
                                  e.ToString());
                Console.WriteLine();
            }
        }

        public void ReadAllAppSettings()
        {
            try
            {
                NameValueCollection appSettings =
                          ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("ReadAppSettings: {0}",
                       "The AppSettings section is empty.");
                    Console.WriteLine();
                }

                for (int i = 0; i < appSettings.Count; i++)
                {
                    Console.WriteLine(
                        "ReadAppSettings: {0} Key: {1} Value: {2}",
                        i,
                        appSettings.GetKey(i), appSettings[i]);
                    Console.WriteLine();
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("ReadAppSettings: {0}",
                                  e.ToString());
                Console.WriteLine();
            }
        }
    }

    
}
