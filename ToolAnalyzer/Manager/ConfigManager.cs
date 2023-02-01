using System;
using System.Configuration;
using System.IO;
using ToolAnalyzer.Properties;

namespace ToolAnalyzer.Manager
{
    public class ConfigManager
    {
        /// <summary>
        ///     Instance object
        /// </summary>
        private static readonly Lazy<ConfigManager> Instance = new Lazy<ConfigManager>(() => new ConfigManager());

        /// <summary>
        ///     Constructor
        /// </summary>
        private ConfigManager()
        {
            // get configuration file path
            var configPath = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            // check file exist
            if (File.Exists(configPath))
                return;
            // upgrade
            Settings.Default.Upgrade();
            Settings.Default.Reload();
            Settings.Default.Save();
        }

        /// <summary>
        ///     Manager
        /// </summary>
        public static ConfigManager Manager => Instance.Value;

        /// <summary>
        ///     Save path
        /// </summary>
        public static string SavePath
        {
            get => Settings.Default.SavePath;
            set => Settings.Default.SavePath = value;
        }

        /// <summary>
        ///     Save configure
        /// </summary>
        public static void Save()
        {
            Settings.Default.Save();
        }
    }
}