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
    public class CopperLivingBowBuff : MinionBuff<CopperLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.copperLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.copperLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Copper Living Bow");
            Description.SetDefault("The copper living bow will shoot enemies with your own arrows!");
        }
    }
}
