using DronesDroidsAndSentries.Items.Accessories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries
{
    public class DDSPlayer : ModPlayer
    {
        // -- LIVING BOWS --
        public bool woodenLivingBow = false;
        public bool copperLivingBow = false;
        public bool tinLivingBow = false;
        public bool ironLivingBow = false;
        public bool leadLivingBow = false;
        public bool silverLivingBow = false;
        public bool tungstenLivingBow = false;
        public bool goldLivingBow = false;
        public bool platinumLivingBow = false;
        public bool livingTendonBow = false;
        public bool livingDemonBow = false;

        // -- LIVING REPEATERS --
        public bool sentientPalladiumRepeater = false;
        public bool sentientCobaltRepeater = false;
        public bool sentientMythrilRepeater = false;
        public bool sentientOrichalcumRepeater = false;
        public bool sentientAdamantiteRepeater = false;
        public bool sentientTitaniumRepeater = false;
        public bool sentientHallowedRepeater = false;
        public bool sentientChlorophyteShotbow = false;

        // -- ENGINEERS SENTRY --
        public bool engineersSentryT1 = false;
        public bool engineersSentryT2 = false;
        public bool engineersSentryT3 = false;

        // -- SUMMONS --
        public bool hoverdrone = false;
        public bool heavyHoverdrone = false;
        public bool hatefulSkull = false;

        // -- ACCESSORIES --
        public bool shoulderMountedGun = false;
        public IngrownRifle ingrownRifle = null;
        public bool atgMk2 = false;

        public override void ResetEffects()
        {
            woodenLivingBow = false;
            copperLivingBow = false;
            tinLivingBow = false;
            ironLivingBow = false;
            leadLivingBow = false;
            silverLivingBow = false;
            tungstenLivingBow = false;
            goldLivingBow = false;
            platinumLivingBow = false;
            livingTendonBow = false;
            livingDemonBow = false;

            sentientPalladiumRepeater = false;
            sentientCobaltRepeater = false;
            sentientMythrilRepeater = false;
            sentientOrichalcumRepeater = false;
            sentientAdamantiteRepeater = false;
            sentientTitaniumRepeater = false;
            sentientHallowedRepeater = false;
            sentientChlorophyteShotbow = false;

            engineersSentryT1 = false;
            engineersSentryT2 = false;
            engineersSentryT3 = false;

            hoverdrone = false;
            heavyHoverdrone = false;

            shoulderMountedGun = false;
            ingrownRifle = null;
            atgMk2 = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            CheckAndFireAtgMk2(target, damage, knockback, crit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            CheckAndFireAtgMk2(target, damage, knockback, crit);
        }

        private void CheckAndFireAtgMk2 (NPC target, int damage, float knockback, bool crit)
        {
            if (atgMk2)
            {
                AtgMk2.TryFire(Player, target, damage, knockback, crit);
            }
        }

        public override void PostUpdate()
        {
            if (ingrownRifle != null)
            {
                IngrownRifle.UpdateRifle(this, ingrownRifle);
            }
        }
    }
}
