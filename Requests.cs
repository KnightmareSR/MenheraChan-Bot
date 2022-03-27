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

namespace The_New_Bot
{
    public class Requests : ModuleBase<SocketCommandContext>
    {


        [Command("request")]
        public async Task Request(params String[] requestItem)
        {


            var path =  @"C:\Users\Chris\Desktop\request.json";
           
            
            
            List<string> item = new List<string>();
            var readable = string.Join(" ", requestItem);
            item.Add(readable);


            ReplyAsync($"{readable} has been added ");

        

            int count = item.Count();

            for (int i = 0; i < count; i++)
            {

                ReplyAsync(item[i].ToString());
            }

            Todo todo = JsonConvert.DeserializeObject<Todo>(path);

            todo.item.ToString();
            Console.WriteLine(todo);
            Console.WriteLine(path);
        }

    }

    public class Todo 
    { 
        public int item { get; set; }
        public bool complete { get; set; }
    }
}
