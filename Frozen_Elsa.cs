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

    public bool IsHooked { get; set; }
    public CBeam? BeamEntity { get; set; }
    public System.Numerics.Vector3 ForwardVector { get; set; }
}
public partial class Frozen_Elsa : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Frozen_Elsa";
    public override string ModuleAuthor => "ASTRAL";
    public override string ModuleDescription => "Adds Grenades Special Effects.";
    public override string ModuleVersion => "V. 0.0.2";

    public required Config Config { get; set; }
    public byte LIFE_ALIVE { get; private set; }

    public void OnConfigParsed(Config config)
    {

        Config = config;
    }


   

    public System.Numerics.Vector3 QAngleToForwardVector(QAngle angle)
    {
        var pitch = (Math.PI / 180) * angle.X;
        var yaw = (Math.PI / 180) * angle.Y;

        var cosPitch = Math.Cos(pitch);
        var sinPitch = Math.Sin(pitch);
        var cosYaw = Math.Cos(yaw);
        var sinYaw = Math.Sin(yaw);

        return new System.Numerics.Vector3((float)(cosPitch * cosYaw), (float)(cosPitch * sinYaw), (float)-sinPitch);
    }

    [GameEventHandler]
    public HookResult OnDecoyStarted(EventDecoyStarted @event, GameEventInfo info)
    {
        var player = @event.Userid; 
        var callerName = player == null ? "Console" : player.PlayerName;


        if (Config is not null)
        {
            // sphere ent

            player?.ExecuteClientCommand($"play sounds/frozen_music2/frozen-go.vsnd_c");

            SphereEntity sphereEntity = new SphereEntity(new Vector(@event.X, @event.Y, @event.Z), 200);
            DrawLaserBetween(sphereEntity.circleInnerPoints, sphereEntity.circleOutterPoints, 5);
            Server.ExecuteCommand($"css_freeze {callerName} 3");
            player?.PrintToChat($"Freeze {callerName} 3 secord");

        }

        return HookResult.Continue;
    }



    private void DrawLaserBetween(Vector[] startPos, Vector[] endPos, float duration)
    {

        for (int i = 0; i < endPos.Length; i++)
        {

            CBeam beam = Utilities.CreateEntityByName<CBeam>("beam");

            //var pawn = player?.PlayerPawn.Get();
            //var activeWeapon = pawn?.WeaponServices?.ActiveWeapon.Get();


            if (beam == null)
            {
                return;
            }
            
                beam.Render = Color.Blue;
                beam.Width = 2.0f;

                beam.Teleport(startPos[i], new QAngle(0), new Vector(0, 0, 0));
                beam.EndPos.X = endPos[i].X;
                beam.EndPos.Y = endPos[i].Y;
                beam.EndPos.Z = endPos[i].Z;



            beam.DispatchSpawn();
            AddTimer(duration, () => { beam.Remove(); });

        }


    }



   





}
