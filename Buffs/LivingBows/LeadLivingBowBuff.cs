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
    public class LeadLivingBowBuff : MinionBuff<LeadLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.leadLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.leadLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Lead Living Bow");
            Description.SetDefault("The lead living bow will shoot enemies with your own arrows!");
        }
    }
}
