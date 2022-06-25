using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries.Items.Accessories
{
    public class IngrownRifle : Accessory
    {
        public const float RANGE = 800;
        public const float COOLDOWN_TIME = 80;
        public const float VELOCITY = 9;
        public static int AMMO_TYPE { get; private set; } = AmmoID.Bullet;

        public const float BULLET_ORIGIN_X = -6;
        public const float BULLET_ORIGIN_Y = -16;

        private float ingrownRifleCooldown = 0f;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.sellPrice(gold: 2, silver: 20);
            Item.rare = ItemRarityID.Blue;
            Item.damage = 14;
            Item.knockBack = 3;
            Item.crit = 4;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("Part bolt-action rifle, part hungry, writhing mass.");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<DDSPlayer>().ingrownRifle = this;
        }

        public static void UpdateRifle(DDSPlayer ddsPlayer, IngrownRifle rifle)
        {
            float range = RANGE;
            Vector2 position = ddsPlayer.Player.Center + new Vector2(BULLET_ORIGIN_X, BULLET_ORIGIN_Y);
            Vector2? targetPos = Utils.FindTarget(position, ref range, x => x.CanBeChasedBy(ddsPlayer.Player, false));
            if (targetPos.HasValue)
            {
                Vector2 dir = targetPos.Value - position;
                float rotation = dir.ToRotation();
                bool fire = false;

                rifle.ingrownRifleCooldown -= 1f;
                if (rifle.ingrownRifleCooldown <= 0f)
                {
                    fire = true;
                    rifle.ingrownRifleCooldown = COOLDOWN_TIME;
                }

                // Fire if we have a target
                if (targetPos.HasValue)
                {
                    if (fire)
                    {
                        if (Main.myPlayer == ddsPlayer.Player.whoAmI)
                        {
                            if (dir == Vector2.Zero)
                            {
                                dir = new Vector2(0f, 1f);
                            }
                            dir.Normalize();
                            dir *= VELOCITY;
                            Item projectileItem = Utils.GetProjectile(ddsPlayer.Player, AMMO_TYPE);
                            if (projectileItem != null)
                            {
                                int proj = Projectile.NewProjectile(ddsPlayer.Player.GetSource_ItemUse_WithPotentialAmmo(projectileItem, projectileItem.shoot), position, dir, projectileItem.shoot, rifle.Item.damage + projectileItem.damage, rifle.Item.knockBack, Main.myPlayer);
                                Main.projectile[proj].timeLeft = 300;
                                Main.projectile[proj].netUpdate = true;
                                Utils.ConsumeAmmo(projectileItem);
                            }
                        }
                    }
                }
            }
        }
    }
}
