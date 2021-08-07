using MultiMiner.Engine.Data;
using MultiMiner.Utility.Net;
using MultiMiner.Utility.OS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MultiMiner.Engine.Installers
{
    public static class AvailableMiners
    {
        public static List<AvailableMiner> GetAvailableMiners(string userAgent)
        {
            //WebClient webClient = new ApiWebClient();
            //webClient.Headers.Add("user-agent", userAgent);

            //string platform = "win32";
            //if (OSVersionPlatform.GetConcretePlatform() == PlatformID.MacOSX)
            //    platform = "osx64";
            
            ////include www. to avoid redirect
            //string url = "http://www.multiminerapp.com/miners?platform=" + platform;
            //string response = webClient.DownloadString(new Uri(url));

            // List<AvailableMiner> availableMiners = JsonConvert.DeserializeObject<List<AvailableMiner>>(response);
            List<AvailableMiner> availableMiners = new List<AvailableMiner>
            {
                new AvailableMiner
                {
                    Name = "BFGMiner",
                    Url = "http://bfgminer.org/files/5.5.0/bfgminer-5.5.0-win32.zip",
                    Version = "5.5.0" 
                },
                new AvailableMiner
                {
                    Name = "SGMinerGM",
                    Url = "https://github.com/genesismining/sgminer-gm/releases/download/5.5.5/sgminer-gm.zip",
                    Version = "5.5.5"
                }
            };

            FixDownloadUrls(availableMiners);

            return availableMiners;
        }

        private static void FixDownloadUrls(List<AvailableMiner> availableMiners)
        {
            FixBFGMinerDownloadUrl(availableMiners);
        }

        private static void FixBFGMinerDownloadUrl(List<AvailableMiner> availableMiners)
        {
            // BFGMiner files are no longer hosted on luke.dashjr.org - see: http://luke.dashjr.org/programs/bitcoin/files/bfgminer/
            // Fixing the URL client-side rather than server-side as the server has not been touched in ~6 years
            var oldMinerUrl = "http://luke.dashjr.org/programs/bitcoin/files/bfgminer/";
            var newMinerUrl = "http://bfgminer.org/files/";
            foreach (var miner in availableMiners)
            {
                miner.Url = miner.Url.Replace(oldMinerUrl, newMinerUrl);
            }
        }
    }
}
