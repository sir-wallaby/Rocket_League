using System;
using Microsoft.Extensions.Configuration;

namespace Rocket_League.Services
{
    public class ConfigurationService
    {
        public string GetRLapiKey()
        {
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;

             IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("_configuration.json")
            .Build();

            string RLSapiKey = configuration["tokens:RLSapi"];       // get the RLSAPI key
            if (string.IsNullOrWhiteSpace(RLSapiKey))
                 throw new Exception("Please go to https://developers.rocketleaguestats.com/manage and register to recieve an API key, or input key into config file.");

            return RLSapiKey;
        }
    }
}
