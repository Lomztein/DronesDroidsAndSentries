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
    public class IronLivingBowBuff : MinionBuff<IronLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.ironLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.ironLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Iron Living Bow");
            Description.SetDefault("The iron living bow will shoot enemies with your own arrows!");
        }
    }
}
