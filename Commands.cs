using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;


namespace DiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("Stats")]
        public async Task Stats() 
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Menhera");
            embed.AddField("Author", "Knightmare#1738");
            embed.AddField("Zee", "Is a woman");
            embed.AddField("Oolong", "WARZONE");
            embed.AddField("@Skirlez#5521 ", "Fucks bananas");
            embed.AddField("Jimmy", "Literally MrBeast");
            embed.AddField("CLASSIC", "BOSHY");
         //   embed.WithImageUrl("https://cdn.discordapp.com/attachments/860782626398666764/903084908891762728/capsule_616x353.png");
            embed.ThumbnailUrl = "https://cdn.discordapp.com/emojis/701648252600320030.png?size=128";

            embed.WithColor(Color.Blue);
            await Context.Channel.SendMessageAsync("", false, embed.Build());


        }


        [Command("Help")]
        public async Task Help() 
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Bot Commands");
            embed.WithDescription("Here are the current bot commands" );

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
        public async Task Invite(IGuildUser user = null)
        {
            var invites = await Context.Guild.GetInvitesAsync();
            await ReplyAsync("  Here you go  " + invites.Select(x => x.Url).FirstOrDefault());
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
        public async Task ChannelTopic() 
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
