using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Interfaces.Receivers {
    public interface IGuildLeftReceiver {
        Task OnGuildLeft(IGuild guild);
    }
}
