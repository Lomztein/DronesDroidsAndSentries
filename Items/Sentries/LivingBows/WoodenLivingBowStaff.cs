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
    public class WoodenLivingBowStaff : SentryStaff
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a wooden living bow that fires at enemies with your own arrows.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 4;
            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.White;
            Item.buffType = ModContent.BuffType<WoodenLivingBowBuff>();
            Item.shoot = ModContent.ProjectileType<WoodenLivingBow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenBow, 1);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}
