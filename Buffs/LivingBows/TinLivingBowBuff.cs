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
    public class TinLivingBowBuff : MinionBuff<TinLivingBow>
    {
        public override bool GetMinionStatus(DDSPlayer player)
            => player.tinLivingBow;

        public override void SetMinionStatus(DDSPlayer player, bool value)
            => player.tinLivingBow = value;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Tin Living Bow");
            Description.SetDefault("The tin living bow will shoot enemies with your own arrows!");
        }
    }
}
