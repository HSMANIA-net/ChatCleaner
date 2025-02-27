using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace ChatCleaner
{
    public class ChatCleaner : BasePlugin
    {
        public override string ModuleName => "ChatCleaner";
        public override string ModuleVersion => "1.0.1";
        public override string ModuleAuthor => "unfortunate";

        private static readonly string[] MoneyMessages =
        {
            "Player_Cash_Award_Kill_Teammate",
            "Player_Cash_Award_Killed_VIP",
            "Player_Cash_Award_Killed_Enemy_Generic",
            "Player_Cash_Award_Killed_Enemy",
            "Player_Cash_Award_Bomb_Planted",
            "Player_Cash_Award_Bomb_Defused",
            "Player_Cash_Award_Rescued_Hostage",
            "Player_Cash_Award_Interact_Hostage",
            "Player_Cash_Award_Respawn",
            "Player_Cash_Award_Get_Killed",
            "Player_Cash_Award_Damage_Hostage",
            "Player_Cash_Award_Kill_Hostage",
            "Player_Point_Award_Killed_Enemy",
            "Player_Team_Award_Killed_Enemy",
            "Team_Cash_Award_T_Win_Bomb",
            "Team_Cash_Award_Loser_Bonus",
            "Team_Cash_Award_no_income"
        };

        public override void Load(bool hotReload)
        {
            HookUserMessage(124, um =>
            {
                for (int i = 0; i < um.GetRepeatedFieldCount("param"); i++)
                {
                    string message = um.ReadString("param", i);
                    if (MoneyMessages.Any(message.Contains))
                    {
                        return HookResult.Stop;
                    }
                }
                return HookResult.Continue;
            },
            HookMode.Pre);
        }

        [GameEventHandler(HookMode.Pre)]
        public HookResult OnPlayerDisconnect(EventPlayerDisconnect @event, GameEventInfo info)
        {
            info.DontBroadcast = true;
            return HookResult.Continue;
        }

        [GameEventHandler(HookMode.Pre)]
        public HookResult OnPlayerTeam(EventPlayerTeam @event, GameEventInfo info)
        {
            @event.Silent = true;
            info.DontBroadcast = true;
            return HookResult.Continue;
        }

    }
}