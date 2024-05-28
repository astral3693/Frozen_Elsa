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
using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;


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

        player?.PrintToCenterHtml($"[{"<img src='http://26.67.120.79/skinplayersweb/img/657ca211c7f7d.jpg' height='50'>"}]</img><br />");





        //player.GiveNamedItem("weapon_m4a1");
        //player.GiveNamedItem("item_kevlar");
    }


    [ConsoleCommand("css_a", "a")]// !dc
    public void OnCommandAItems(CCSPlayerController? player, CommandInfo commandInfo)
    {
        if (player == null) return;
        if (!player.IsValid) return;

        var callerName = player == null ? "Console" : player.PlayerName;
        player?.ExecuteClientCommand($"play sounds/marius_music/ala-se-amari-yah-aaa-baba-yah-abadon.vsnd");


    }

    
}