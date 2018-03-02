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
        [Remarks("Basic command to retrieve some kind of info from RL Stats")]
        public async Task singlePlayerStats([Remainder] string RlUsernameInputtedByUser)
        {   //create the builder to output into the Discord chat window
            var builder = new EmbedBuilder()
            {
                Color = new Color(100, 65, 200),
                Description = "\n"

            };

            Services.ConfigurationService RLconfig = new Services.ConfigurationService();

            var apiKey = RLconfig.GetRLapiKey();

            var client = new RLSClient(apiKey);

            // Retrieve a single player on PS4
            var player = await client.GetPlayerAsync(RlsPlatform.Ps4, RlUsernameInputtedByUser);
            var playerSeasonSeven = player.RankedSeasons.FirstOrDefault(x => x.Key == RlsSeason.Seven);

            if (playerSeasonSeven.Value != null)
            {
                builder.Description = builder.Description + "\n" + $"Display Name: {player.DisplayName}";

                foreach (var playerRank in playerSeasonSeven.Value)
                {
                    builder.Description = builder.Description + "\n" + $"{playerRank.Key}: {playerRank.Value.RankPoints} rating";
                }

                builder.Description = builder.Description + "\n" + "Platform: " + player.Platform.Name;
                builder.Description = builder.Description + "\n" + "wins: " + player.Stats.Wins;
                
            }          
            
            await ReplyAsync("", false,builder.Build());
        }           
    }
}
