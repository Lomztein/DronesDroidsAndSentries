using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries.Items.Sentries
{
    public abstract class SentryStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item44;
            Item.width = 16;
            Item.height = 16;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.DamageType = DamageClass.Summon;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (HasRoomForTurret(player, type))
            {
                var proj = Projectile.NewProjectileDirect(source, Main.MouseWorld, velocity, type, damage, knockback, Main.myPlayer);
                proj.originalDamage = damage;
                player.AddBuff(Item.buffType, 2);
            }
            return false;
        }

        public bool HasRoomForTurret(Player player, int type)
        {
            Projectile proj = ContentSamples.ProjectilesByType[type];
            int currentCount = (int)GetPlayerTurretCount(player);
            return GetPlayerMaxTurrets(player) >= currentCount + proj.minionSlots;
        }

        public float GetPlayerTurretCount(Player player)
        {
            float turretCount = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];
                if (p.active && p.sentry && p.owner == player.whoAmI)
                {
                    turretCount += p.minionSlots;
                }
            }
            return turretCount;
        }

        public int GetPlayerMaxTurrets(Player player)
        {
            return player.maxTurrets;
        }
    }
}
