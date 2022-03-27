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
using Lavalink4NET;
using Lavalink4NET.DiscordNet;
using Victoria;
using Newtonsoft.Json;

namespace DiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {



        private async Task HandlecommandAsync(SocketMessage msg)
        {
            var message = msg as SocketUserMessage;
            var blacklistedWords = new List<string>();

            blacklistedWords.Add("Free discord nitro");

            msg.ToString().ToLower();


            if (message.Content.Contains(blacklistedWords.FirstOrDefault()))
            {
                await message.DeleteAsync();
                await message.Author.SendMessageAsync("Hello");
            }


        }

        [Command("..bred")]
        public async Task Bred()
        {
            List<string> bred = new List<string>();
            bred.Add("");
            bred.Add("");
            bred.Add("");
            bred.Add("");

            Random rnd = new Random();
            int index = rnd.Next(bred.Count);
            await ReplyAsync($"{ bred[index]}");

        }


        [Command("Fumo")]
        public async Task Fumo()
        {
            #region  
            List<string> fumoGifs = new List<string>();
            fumoGifs.Add("https://tenor.com/view/rei-ayanami-plush-fumo-gif-24291059");
            fumoGifs.Add("https://tenor.com/view/touhou-fumo-touhou-fumo-plush-gif-23217054");
            fumoGifs.Add("https://tenor.com/view/yuyuko-fumo-touhou-doll-plush-gif-20972293");
            fumoGifs.Add("https://tenor.com/view/touhou-ok-and-cirno-gif-22104990");
            fumoGifs.Add("https://tenor.com/view/fumo-touhou-fumo-fumo-plush-yuyuko-fumo-yuyuko-gif-23084836");
            fumoGifs.Add("https://tenor.com/view/patchouli-knowledge-patchy-fumo-fumofumo-bop-gif-23498405");
            fumoGifs.Add("https://tenor.com/view/touhou-fumo-cirno-fumo-murasa-fumo-cirno-murasa-murasa-gif-22948388");
            fumoGifs.Add("https://cdn.discordapp.com/attachments/680096876842057738/857072623552299038/1447139527086.gif");
            fumoGifs.Add("https://tenor.com/view/cirno-cirno-fumo-fumo-gif-21728275");
            fumoGifs.Add("https://tenor.com/view/fumo-fumo-touhou-fumo-plush-touhou-flandre-gif-24379735");
            fumoGifs.Add("https://tenor.com/view/touhou-fumo-flandre-generator-gif-19559237");
            fumoGifs.Add("https://cdn.discordapp.com/attachments/861040876264226827/861041003082940416/video0.mp4");
            fumoGifs.Add("https://tenor.com/view/hakurei-reimu-fumo-fumo-fumo-fumo-doll-el-transporte-gif-20650216");
            #endregion
            Random rnd = new Random();
            int index = rnd.Next(fumoGifs.Count);
            await ReplyAsync($"{ fumoGifs[index]}");

            Console.WriteLine($"{ fumoGifs.Count.ToString()} total fumos");



        }

        [Command("Message")]
        public async Task SendMSG(params String[] message)
        {
            var readable = string.Join(" ", message);
            await ReplyAsync(readable);
        }


        [Command("User")]
        public async Task userInfo(SocketUser user) 
        {
           
            

           var avi = user.GetAvatarUrl();
           var created = user.CreatedAt;
            var embed = new EmbedBuilder();
            var activ = user.Status;

            embed.ThumbnailUrl = avi;
            embed.WithTitle("User info ");
            embed.WithDescription($"{user.Mention}  Profile Info ");
            embed.AddField($" {created} ", "Date Created ", true);
            embed.AddField($"User is {activ} ", " Status", false);
            embed.WithColor(Color.Blue);
         
            var sent = await Context.Channel.SendMessageAsync("", false, embed.Build());

        }
       

        [Command("Poll")]
        public async Task Poll(  string emote, string emote2,  params String[] message)
        {


            var readable = string.Join(" ", message);
            var poll = new EmbedBuilder();
            var emoji = new Emoji(emote);
            var emoji1 = new Emoji(emote2);
            var author = Context.Message.Author;

            poll.WithTitle($"{author} has started a poll vote below :page_with_curl: ");
            poll.WithDescription(readable);
            poll.AddField($"Yes {emoji}", $"No {emoji1}");
            poll.WithColor(Color.Blue);
            var sent = await Context.Channel.SendMessageAsync("", false, poll.Build());
            await sent.AddReactionAsync(emoji);
            await sent.AddReactionAsync(emoji1);

        }
       
        [Command("About")]
        public async Task Stats() 
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Menhera");
            embed.AddField("Author", "Knightmare#1738");
        
           // embed.WithImageUrl("https://cdn.discordapp.com/attachments/680096876842057738/916257377702006844/250.png");
            embed.ThumbnailUrl = "https://cdn.discordapp.com/emojis/809322723720429580.gif?size=128";

            embed.WithColor(Color.Blue);
            await Context.Channel.SendMessageAsync("", false, embed.Build());


        }


        [Command("Help")]
        public async Task Help() 
        {
            var embed = new EmbedBuilder();
            var author = Context.Message.Author;

            embed.WithTitle("Bot Commands");
            embed.WithDescription($" {author} Here are the current bot commands" );

            embed.AddField("***.Prune***", "(Amount)", true);

            embed.AddField(".Kick ", "(Member)");

            embed.AddField(".Ban ", "(Member)");

            embed.AddField(".Invite ", "To recieve an invite link");



            embed.WithColor(Color.Blue);
            await Context.Channel.SendMessageAsync("", false, embed.Build());


        }

        [Command("Kick")]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "Invalid Permission to kick this user!")]

        public async Task Kick(IGuildUser user, [Remainder] string reason = null)
        {

            if (user.GuildPermissions.KickMembers)
            {
                await user.KickAsync(reason);

            }

            else

            {
                await user.KickAsync();
            }


            var EmbedBuilder = new EmbedBuilder()

              .WithDescription($":white_check_mark: {user.Mention} Was Kicked!\n**Reason** {reason}")
            .WithFooter(footer =>

            {
                footer
                .WithText("User Kick Log");
            });

            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);

            ITextChannel logChannel = Context.Client.GetChannel(838954527292915773) as ITextChannel;

            var EmbedBuilderLog = new EmbedBuilder()

         .WithDescription($"{user.Mention} Was Banned!\n**Reason** {reason}\n**Moderator** {Context.User.Mention}")
         .WithFooter(footer =>


         {

             footer
             .WithText("User Kick Log");

         });

            Embed embedLog = EmbedBuilderLog.Build();
            await
            logChannel.SendMessageAsync(embed: embedLog);



        }

        [Command("Invite")]
        public async Task Invite()
        {
            var invites = await Context.Guild.GetInvitesAsync();
            var giveInvite =  invites.Select(x => x.Url).FirstOrDefault();
            var embed = new EmbedBuilder();

            //   await ReplyAsync("  Here you go  " + invites.Select(x => x.Url).FirstOrDefault());

            embed.AddField("", await ReplyAsync( giveInvite, true));
            embed.WithColor(Color.Blue);
            await Context.Channel.SendMessageAsync("Hello", false, embed.Build());
        }



        [Command("Prune")]
        [Summary("Mass Deletes Messages")]

        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "Invalid Permission to prune!")]
        public async Task Prune(int amount)
        {

            IEnumerable<IMessage> messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
            const int delay = 3000;
            IUserMessage m = await ReplyAsync($"I have deleted {amount} messages ");
            await Task.Delay(delay);
            await m.DeleteAsync();

        }

        [Command("CT")]
        public async Task ChannelTopic(IChannel channel) 
        {
           
        }


        [Command("Ban")]

        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "Invalid Permission to ban this user!")]
        public async Task BanMemeber(IGuildUser user = null, [Remainder] string reason = null)
        {
            if (user == null)
            {
                await ReplyAsync("Please Specify a user!");
                return;

            }
            if (reason == null) reason = "Not Specified";


            await Context.Guild.AddBanAsync(user, 1, reason);

            var EmbedBuilder = new EmbedBuilder()


            .WithDescription($":white_check_mark: {user.Mention} Was Banned!\n**Reason** {reason}")
            .WithFooter(footer =>



            {


                footer
                .WithText("User Ban Log");



            });

            Embed embed = EmbedBuilder.Build();
            await ReplyAsync(embed: embed);


            ITextChannel logChannel = Context.Client.GetChannel(838954527292915773) as ITextChannel;

            var EmbedBuilderLog = new EmbedBuilder()


         .WithDescription($"{user.Mention} Was Banned!\n**Reason** {reason}\n**Moderator** {Context.User.Mention}")
         .WithFooter(footer =>

         {

             footer
             .WithText("User Ban Log");

         });

            Embed embedLog = EmbedBuilderLog.Build();
            await
            logChannel.SendMessageAsync(embed: embedLog);

        }

    }
}
