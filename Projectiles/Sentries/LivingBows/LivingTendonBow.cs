using DronesDroidsAndSentries.Projectiles.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace DronesDroidsAndSentries.Projectiles.Sentries.LivingBows
{
    public class LivingTendonBow : SentryMinion
    {
        protected override bool GetMinionStatus(DDSPlayer modPlayer)
            => modPlayer.livingTendonBow;

        protected override void SetMinionStatus(DDSPlayer modPlayer, bool value)
            => modPlayer.livingTendonBow = value;

        public override void SetDefaults()
        {
            base.SetDefaults();
            AmmoType = AmmoID.Arrow;
            Cooldown = 30f * 3;
            ShootSpeed = 15f;

            Projectile.width = 8;
            Projectile.height = 16;
        }
    }
}
