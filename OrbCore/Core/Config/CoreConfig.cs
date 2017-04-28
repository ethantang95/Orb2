using HelperCore.Optional;
using OrbCore.Interfaces.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbCore.Core.Config {
    public class CoreConfig {
        public string LoginToken { get; set; }
        public Optional<string> StartingGame { get; set; }

        public CoreConfig(string loginToken) {
            LoginToken = loginToken;
            StartingGame = Optional<string>.FromNull();
        }
    }
}
