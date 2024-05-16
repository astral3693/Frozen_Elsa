using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;
using Frozen_music.Config;
using System.Text;


namespace Frozen_Elsa;

public partial class Frozen_Elsa
{


    [ConsoleCommand("css_teste", "Freeze a player.")]
    [CommandHelper(1, "<#userid or name or @me> [duration]")]
    [RequiresPermissions("@css/slay")]
    public void OnFreezeCommand(CCSPlayerController? caller, CommandInfo command)
    {

        var callerName = caller == null ? "Console" : caller.PlayerName;
        int.TryParse(command.GetArg(2), out var time);

        var targets = GetTarget(command);
        var playersToTarget = targets!.Players.Where(player => player is { IsValid: true, PawnIsAlive: true, IsHLTV: false }).ToList();


        playersToTarget.ForEach(player =>
        {
            if (!player.IsBot && player.SteamID.ToString().Length != 17)
                return;

            
                Freeze(caller, player, time, callerName);
           
        });
    }

    public void Freeze(CCSPlayerController? caller, CCSPlayerController? player, int time, string? callerName = null)
    {
        // Assuming callerName is optional and can be null
        string command = $"css_freeze {callerName} {time}";  // String formatting with interpolated string literals

        

        player.PrintToChat(command);

        player.ExecuteClientCommand("play " + Configs.GetConfigData().frozengo);
        player.ExecuteClientCommand(command);

    }

    public void Unfreeze(CCSPlayerController? caller, CCSPlayerController? player, string? callerName = null, CommandInfo? command = null)
    {
        callerName ??= caller == null ? "Console" : caller.PlayerName;

       
    }

}