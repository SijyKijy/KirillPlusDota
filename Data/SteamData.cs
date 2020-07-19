using Newtonsoft.Json;
using System;

namespace KirillPlusDota.Data
{
    internal class SteamData
    {
        [JsonProperty("personaname")]
        public string Name { get; set; }
        [JsonProperty("profileurl")]
        public string URL { get; set; }
        [JsonProperty("personastate")]
        public State State { get; set; }
        [JsonProperty("gameextrainfo")]
        public string Game { get; set; }
    }

    [Flags]
    internal enum State
    {
        Offline,
        Online,
        Busy,
        Away,
        Snooze,
        LookTrade,
        LookPlay
    }
}
