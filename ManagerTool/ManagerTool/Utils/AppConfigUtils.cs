using System;
using System.Configuration;

namespace ManagerTool {
    static class AppConfigUtils {
        /// <summary>
        /// Updates the value of a given parameter in the App.config
        /// </summary>
        /// <param name="key">Parameter key/name</param>
        /// <param name="value">New value to assign</param>
        public static void SaveAppConfigKeyValue(string key, string value) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
