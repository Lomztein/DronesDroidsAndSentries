using DronesDroidsAndSentries.Projectiles.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace DronesDroidsAndSentries.Projectiles.Sentries.LivingBows
{
    public class IronLivingBow : SentryMinion
    {
        protected override bool GetMinionStatus(DDSPlayer modPlayer)
            => modPlayer.ironLivingBow;

        protected override void SetMinionStatus(DDSPlayer modPlayer, bool value)
            => modPlayer.ironLivingBow = value;

        public override void SetDefaults()
        {
            base.SetDefaults();
            AmmoType = AmmoID.Arrow;
            Cooldown = 28f * 3;
            ShootSpeed = 12f;

            Projectile.width = 8;
            Projectile.height = 16;
        }
    }
}
