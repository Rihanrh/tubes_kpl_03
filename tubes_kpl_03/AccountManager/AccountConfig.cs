using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccountManager
{
    public class Config
    {
        public string tipe_akun { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Config() { }

        public Config(string tipe_akun, string username, string password)
        {
            this.tipe_akun = tipe_akun;
            this.username = username;
            this.password = password;
        }
    }

    public class AccountConfig
    {
        public Config config;
        public const string filePath = @"./acc_config.json";

        public AccountConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        public Config ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private void SetDefault()
        {
            config = new Config("Pembeli", "username", "password");
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

    }
}
