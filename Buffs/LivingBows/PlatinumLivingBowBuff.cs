using DronesDroidsAndSentries.Projectiles.Sentries.LivingBows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries.Buffs.LivingBows
{
    public class PlatinumLivingBowBuff : MinionBuff<PlatinumLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.platinumLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.platinumLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Wooden Living Bow");
            Description.SetDefault("The wooden living bow will shoot enemies with your own arrows!");
        }
    }
}
