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
    public class GoldLivingBowBuff : MinionBuff<GoldLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.goldLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.goldLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Gold Living Bow");
            Description.SetDefault("The gold living bow will shoot enemies with your own arrows!");
        }
    }
}
