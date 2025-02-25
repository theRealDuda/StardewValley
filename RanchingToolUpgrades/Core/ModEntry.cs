using StardewModdingAPI;
using StardewModdingAPI.Events;
using BirbShared.APIs;
using BirbShared.Mod;

namespace RanchingToolUpgrades
{
    internal class ModEntry : Mod
    {
        [SmapiInstance]
        public static ModEntry Instance;
        [SmapiConfig]
        public static Config Config;
        [SmapiCommand]
        public static Command Command;
        [SmapiAsset]
        public static Assets Assets;
        [SmapiApi(UniqueID = "spacechase0.SpaceCore")]
        public static ISpaceCore SpaceCore;

        public override void Entry(IModHelper helper)
        {
            ModClass mod = new ModClass();
            mod.Parse(this, true);
            mod.ApisLoaded += this.ModClassParser_ApisLoaded;
        }

        private void ModClassParser_ApisLoaded(object sender, OneSecondUpdateTickedEventArgs e)
        {
            SpaceCore.RegisterSerializerType(typeof(UpgradeablePail));
            SpaceCore.RegisterSerializerType(typeof(UpgradeableShears));
        }
    }
}
