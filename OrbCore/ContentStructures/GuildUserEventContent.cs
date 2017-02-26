using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.ContentStructures {
    public class GuildUserEventContent {
        public IUser User { get; private set; }
        public IGuild Guild { get; private set; }

        internal GuildUserEventContent(IUser user, IGuild guild) {
            User = user;
            Guild = guild;
        }
    }
}
