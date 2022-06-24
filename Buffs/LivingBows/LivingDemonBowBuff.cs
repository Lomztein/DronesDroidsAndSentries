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
    public class LivingDemonBowBuff : MinionBuff<LivingDemonBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.livingDemonBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.livingDemonBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Living Demon Bow");
            Description.SetDefault("The demonic living bow will shoot enemies with your own arrows!");
        }
    }
}
