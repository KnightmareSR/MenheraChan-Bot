using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Discord.Interactions;



namespace The_New_Bot
{
    public class Requests : ModuleBase<SocketCommandContext>
    {


        DiscordSocketClient client;

        public async Task MainAsync() 
        {
           // client.ButtonExecuted += MyButtonHandler;

            

        }



        [Command("request")]
        public async Task Request(  params String[] requestItem)
        {

            
            

            var builder = new ComponentBuilder()
                .WithButton("Accept", "accept-button");

           await ReplyAsync("Click to accept button", components: builder.Build());





        }



    /*    private async Task HandleInteractionCreated(SocketInteraction interaction)
        {
            switch (interaction.Type)
            {
                case InteractionType.ApplicationCommand:
                    //Handle SlashCommands
                    break;
                case InteractionType.ApplicationCommandAutocomplete:
                    //Handle Autocomplete
                    break;
                case InteractionType.MessageComponent:
                 //   MessageComponentHandlingService.MessageComponentHandler(interaction)
                    break;
                default: // We dont support it
                    Console.WriteLine("Unsupported interaction type: " + interaction.Type);
                    break;
            }
        }
    */

    }




}
