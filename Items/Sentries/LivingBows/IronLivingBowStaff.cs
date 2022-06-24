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
    public class IronLivingBowStaff : SentryStaff
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons an iron living bow that fires at enemies with your own arrows.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 8;
            Item.value = Item.buyPrice(silver: 4);
            Item.rare = ItemRarityID.White;
            Item.buffType = ModContent.BuffType<IronLivingBowBuff>();
            Item.shoot = ModContent.ProjectileType<IronLivingBow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBow, 1);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.Amethyst, 2);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}
