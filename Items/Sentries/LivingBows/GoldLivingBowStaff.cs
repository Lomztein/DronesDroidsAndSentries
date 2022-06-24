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
    public class GoldLivingBowStaff : SentryStaff
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a gold living bow that fires at enemies with your own arrows.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 11;
            Item.value = Item.buyPrice(silver: 20);
            Item.rare = ItemRarityID.White;
            Item.buffType = ModContent.BuffType<GoldLivingBowBuff>();
            Item.shoot = ModContent.ProjectileType<GoldLivingBow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBow, 1);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}
