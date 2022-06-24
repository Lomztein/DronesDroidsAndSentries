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
    public class LivingTendonBowBuff : MinionBuff<LivingTendonBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.livingTendonBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.livingTendonBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Living Tendon Bow");
            Description.SetDefault("The living tendon bow will shoot enemies with your own arrows!");
        }
    }
}
