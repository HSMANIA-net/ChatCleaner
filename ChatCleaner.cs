using System.Globalization;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace ChatCleaner
{
    public class ChatCleaner : BasePlugin
    {
        public override string ModuleName => "ChatCleaner";
        public override string ModuleVersion => "1.0.0";
        public override string ModuleAuthor => "unfortunate";

        // TODO: Hide disconnect message
        [GameEventHandler(HookMode.Pre)]
        public HookResult OnPlayerTeam(EventPlayerTeam @event, GameEventInfo info)
        {
           @event.Silent = true;
           info.DontBroadcast = true;
           return HookResult.Continue;
        }

    }
}