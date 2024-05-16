using System.Text.Json.Serialization;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using static CounterStrikeSharp.API.Core.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection.Metadata;

using CounterStrikeSharp.API.Modules.Timers;
using CounterStrikeSharp.API.Modules.Memory;
using Frozen_music.Config;
using CounterStrikeSharp.API.Modules.Commands.Targeting;
using CounterStrikeSharp.API.Modules.Commands;

namespace Frozen_Elsa;
public class Config : BasePluginConfig
{

    public bool SiteImage { get; set; } = true;
    [JsonPropertyName("show-player-counter")]
    public bool PlayerCounter { get; set; } = true;
    [JsonPropertyName("ConfigVersion")]
    public override int Version { get; set; } = 2;
}
public partial class Frozen_Elsa : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Frozen_Elsa";
    public override string ModuleAuthor => "Amauri Bueno dos Santos";
    public override string ModuleDescription => "Adds Grenades Special Effects.";
    public override string ModuleVersion => "V. 0.0.1";

    public required Config Config { get; set; }

    public void OnConfigParsed(Config config)
    {

        Config = config;
    }

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventPlayerHurt>(OnPlayerHurt);
    }
   

    private HookResult OnPlayerHurt(EventPlayerHurt @event, GameEventInfo info)
    {
        if (@event == null) return HookResult.Continue;
        var victim = @event.Userid;
        var attacker = @event.Attacker;
        var hitgroup = @event.Hitgroup;

        if (victim == null || !victim.IsValid) return HookResult.Continue;
        if (attacker == null || !attacker.IsValid || attacker.IsBot) return HookResult.Continue;

        if (attacker != victim)
        {
            if (attackerThrewSmokeRecently())
            {
                attacker.ExecuteClientCommand("play " + Configs.GetConfigData().frozengo);
            }
            else
            {
                if (!string.IsNullOrEmpty(Configs.GetConfigData().frozengo))
                {
                    attacker.ExecuteClientCommand("play " + Configs.GetConfigData().frozengo);
                }
            }
        }

        return HookResult.Continue;

    }

    private static TargetResult? GetTarget(CommandInfo command)
    {
        var matches = command.GetArgTargetResult(1);

        if (!matches.Any())
        {
            command.ReplyToCommand($"Target {command.GetArg(1)} not found.");
            return null;
        }

        if (command.GetArg(1).StartsWith('@'))
            return matches;

        if (matches.Count() == 1)
            return matches;

        command.ReplyToCommand($"Multiple targets found for \"{command.GetArg(1)}\".");
        return null;
    }

    // Helper function to check if attacker threw a smoke grenade recently (replace with your game-specific logic)
    private bool attackerThrewSmokeRecently()
    {
        // ... (your implementation to check for smoke grenade usage)
        return false; // Placeholder, replace with actual logic
    }
}