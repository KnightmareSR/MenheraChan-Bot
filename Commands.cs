using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;


namespace DiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {










        //var _invite = await _server.CreateInvite(maxAge: null, maxUses: 25, tempMembership: false, withXkcd: false);


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
