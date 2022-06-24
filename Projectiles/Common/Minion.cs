using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries.Projectiles.Common
{
    public abstract class Minion : ModProjectile
    {
        public int AmmoType { get; protected set; }

        public float Range { get; protected set; } = 500;
        public float Cooldown { get; protected set; } = 90f;
        public float ShootSpeed { get; protected set; } = 10f;

        public override void SetStaticDefaults()
        {
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = Projectile.SentryLifeTime;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            CheckActive();
            Behavior();
        }

        private void CheckActive()
        {
            Player player = Main.player[Projectile.owner];
            DDSPlayer modPlayer = player.GetModPlayer<DDSPlayer>();
            if (player.dead)
            {
                SetMinionStatus(modPlayer, false);
            }
            if (GetMinionStatus(modPlayer))
            {
                Projectile.timeLeft = 2;
            }
        }

        protected abstract bool GetMinionStatus(DDSPlayer modPlayer);

        protected abstract void SetMinionStatus(DDSPlayer modPlayer, bool value);

        protected abstract void Behavior();

        protected Item GetProjectile()
        {
            Player player = Main.player[Projectile.owner];
            return player.inventory.LastOrDefault(x => x.stack > 0 && x.active && IsAmmoType(x.ammo));
        }

        protected virtual bool IsAmmoType(int ammo)
        {
            return AmmoType == ammo;
        }

        protected virtual void ConsumeAmmo(Item ammoItem)
        {
            if (ammoItem.maxStack > 1 && ammoItem.stack < 3996) // Not infinite.
            {
                ammoItem.stack--;
            }
        }

        protected virtual Vector2? FindTarget(ref float targetDist)
        {
            Player player = Main.player[Projectile.owner];
            Vector2? targetPos = null;

            // If the player has whipped something, target that.
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height))
                {
                    targetPos = npc.Center;
                }
            }
            else
            {
                for (int k = 0; k < 200; k++)
                {
                    NPC npc = Main.npc[k];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(npc.Center, Projectile.position);
                        if (distance < targetDist && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            targetPos = npc.Center;
                        }
                    }
                }
            }

            return targetPos;
        }
    }
}
