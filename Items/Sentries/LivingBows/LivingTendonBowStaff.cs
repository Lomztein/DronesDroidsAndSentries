using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using DronesDroidsAndSentries.Projectiles.Sentries.LivingBows;
using DronesDroidsAndSentries.Buffs.LivingBows;

namespace DronesDroidsAndSentries.Items.Sentries.LivingBows
{
    public class LivingTendonBowStaff : SentryStaff
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a living tendon bow that fires at enemies with your own arrows.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 19;
            Item.value = Item.buyPrice(silver: 45);
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<LivingTendonBowBuff>();
            Item.shoot = ModContent.ProjectileType<LivingTendonBow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TendonBow, 1);
            recipe.AddIngredient(ItemID.Shadewood, 8);
            recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}
