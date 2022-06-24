using DronesDroidsAndSentries.Projectiles.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace DronesDroidsAndSentries.Projectiles.Sentries.LivingBows
{
    public class LeadLivingBow : SentryMinion
    {
        protected override bool GetMinionStatus(DDSPlayer modPlayer)
            => modPlayer.woodenLivingBow;

        protected override void SetMinionStatus(DDSPlayer modPlayer, bool value)
            => modPlayer.woodenLivingBow = value;

        public override void SetDefaults()
        {
            base.SetDefaults();
            AmmoType = AmmoID.Arrow;
            Cooldown = 90f;
            ShootSpeed = 10f;

            Projectile.width = 8;
            Projectile.height = 16;
        }
    }
}
