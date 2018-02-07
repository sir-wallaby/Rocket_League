using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLSApi.Data;
using RLSApi.Net.Requests;
using RLSApi;

namespace Rocket_League.Modules
{
  
    public class RocketLeagueModule : ModuleBase
    {
      

        [Command("rl")] //how to actually call the bot to do something
        [Remarks("")]
        public async Task singlePlayerStats([Remainder] string RlUsernameInputtedByUser)
        {
            var builder = new EmbedBuilder()
            {
                Color = new Color(100, 65, 200),
                Description = "\n"

            };

            Services.ConfigurationService RLconfig = new Services.ConfigurationService();
            var apiKey = RLconfig.GetRLapiKey();

            var client = new RLSClient(apiKey);

            // Retrieve a single player.
            var player = await client.GetPlayerAsync(RlsPlatform.Ps4, RlUsernameInputtedByUser);
            var playerSeasonSix = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Six);

            if (playerSeasonSix.Value != null)
            {
                builder.Description = builder.Description + "\n" + $"# Player: {player.DisplayName}";

                foreach (var playerRank in playerSeasonSix.Value)
                {
                    builder.Description = builder.Description + "\n" + $"{playerRank.Key}: {playerRank.Value.RankPoints} rating";
                }
            }        

           
            
            await ReplyAsync("", false,builder.Build());
        }

    }
    
}
