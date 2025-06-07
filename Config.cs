using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Scp3114AutoFF
{
    public class Config : IConfig
    {
        [Description("Whether Friendly Fire should be enabled for SCP-3114 players. " +
                     "If set to true, SCP-3114 players will have friendly fire enabled by default. " +
                     "If set to false, friendly fire will be disabled for SCP-3114 players. " +
                     "This can be toggled in-game by SCP-3114 players using the command /scpfriendlyfire.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Whether the plugin should send informations about its informations to the console.")]
        public bool Debug { get; set; } = false;
    }
}
