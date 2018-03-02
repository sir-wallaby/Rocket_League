﻿using Discord.Commands;
using System;
using System.Threading.Tasks;
using Rocket_League.Services;

namespace Rocket_League.Modules
{
    public class TestModule : ModuleBase
    {     

        [Command("test")] //how to actually call the bot to do something
        [Remarks("blah blah, testing bot code")]
        public async Task test()
        {

            try
            {
                await ReplyAsync(DefineAnewMethod());
            }
            catch (Exception e)
            {
                await ReplyAsync(e.ToString());
            }
        }

    //Not really any Code, Just testing out GIT commands on windows
        public string DefineAnewMethod()
        {
            String someText;
            someText = " Hi, I am a  method, I just want to be represented";

            return someText;
        }
    }

}
 