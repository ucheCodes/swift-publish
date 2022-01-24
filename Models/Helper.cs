using System;
using System.Collections;
using System.Collections.Generic;
using  Gitless_api.Database;
using  Gitless_api.Models;
using Newtonsoft.Json;  
using System.Linq;

namespace Gitless_api.Models
{
    public static class Helper
    {
        public static List<Connections> GetUserSignalRId(string userId)
        {
            var online = database.ReadAll("SignalrConnections");
            if (online.Count > 0)
            {
               var con = new List<Connections>();
               online.ForEach(c => con.Add(JsonConvert.DeserializeObject<Connections>(c.Value)));
               var userOnline = con.Where(c => c.UserId == userId);
                if (userOnline.Count() > 0)
                {
                    return con;
                }
            }
            return new List<Connections>();
        }
    }
}