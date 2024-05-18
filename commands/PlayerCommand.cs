using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;
using Frozen_music.Config;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;


namespace Frozen_Elsa;

public partial class Frozen_Elsa
{
    


    [ConsoleCommand("css_dc", "dc")]// !dc
    public void OnCommandGiveItems(CCSPlayerController? player, CommandInfo commandInfo)
    {
        if (player == null) return;
        if (!player.IsValid) return;


        var callerName = player == null ? "Console" : player.PlayerName;
        

        //Server.ExecuteCommand($"css_freeze {callerName} 9");
        //player?.PrintToChat($"Freeze {callerName} 9 secord");


        //player?.ExecuteClientCommand($"play sounds/ui/counter_beep.vsnd");
        
        player?.ExecuteClientCommand($"play sounds/frozen_music2/frozen-ice.vsnd_c");

        player?.GiveNamedItem("weapon_Decoy");

        


        //player.GiveNamedItem("weapon_m4a1");
        //player.GiveNamedItem("item_kevlar");
        //player.GiveNamedItem("weapon_tec9");
    }
}