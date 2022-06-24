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
    public class TungstenLivingBowBuff : MinionBuff<TungstenLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.tungstenLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.tungstenLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Tungsten Living Bow");
            Description.SetDefault("The tungsten living bow will shoot enemies with your own arrows!");
        }
    }
}
