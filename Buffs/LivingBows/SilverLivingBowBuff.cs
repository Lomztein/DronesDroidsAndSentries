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
    public class SilverLivingBowBuff : MinionBuff<SilverLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.silverLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.silverLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Silver Living Bow");
            Description.SetDefault("The silver living bow will shoot enemies with your own arrows!");
        }
    }
}
