using CounterStrikeSharp.API.Core;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Frozen_Elsa;

public class Globals
{
    private const int PLAYER_ONFIRE = (1 << 24);

    private bool[] bUserHasFrozen = new bool[33];
    private string g_FreezeSound = "";


    private float fVolume;

    private const string IceModel = "models/weapons/eminem/ice_cube/ice_cube.mdl";
    private const string IceCube3d = "materials/weapons/eminem/ice_cube/ice_cube.vmt";

    private static readonly float[] NULL_VELOCITY = { 0.0f, 0.0f, 0.0f };

    private Handle g_LightningSprite;
    private Handle g_HaloSprite;

    private float g_Time = 3;

    private int modelindex;
    private int haloindex;

    private Handle h_greneffects_enable;
    private bool b_enable;
    private Handle h_greneffects_trails;
    private bool b_trails;

    private Handle h_greneffects_napalm_he;
    private bool b_napalm_he;
    private float f_napalm_he_duration;

    private Handle h_greneffects_smoke_freeze;
    private bool b_smoke_freeze;
    private float f_smoke_freeze_distance;
    private float f_smoke_freeze_duration;

    private Handle h_greneffects_flash_light;
    private bool b_flash_light;
    private float f_flash_light_distance;
    private float f_flash_light_duration;

    private Handle mp_friendlyfire;
    private bool b_friendlyfire;


    private Handle h_fwdOnClientFreeze;
    private Handle h_fwdOnClientFreezed;


    public static int Takefreezetime;
    public static Stopwatch Timers = new Stopwatch();
    public static bool First_Blood = false;
    public static Dictionary<ulong, int> Kill_Streak = new Dictionary<ulong, int>();
    public static Dictionary<ulong, int> Kill_StreakHS = new Dictionary<ulong, int>();
    public static Dictionary<ulong, int> Kill_Knife = new Dictionary<ulong, int>();
    public static Dictionary<ulong, int> Kill_Nade = new Dictionary<ulong, int>();
    public static Dictionary<ulong, int> Kill_Molly = new Dictionary<ulong, int>();
    public static Dictionary<ulong, DateTime> lastPlayTimes = new Dictionary<ulong, DateTime>();
    public static Dictionary<ulong, DateTime> lastPlayTimesHS = new Dictionary<ulong, DateTime>();
    public static Dictionary<ulong, DateTime> lastPlayTimesKnife = new Dictionary<ulong, DateTime>();
    public static Dictionary<ulong, DateTime> lastPlayTimesNade = new Dictionary<ulong, DateTime>();
    public static Dictionary<ulong, DateTime> lastPlayTimesMolly = new Dictionary<ulong, DateTime>();


    
}