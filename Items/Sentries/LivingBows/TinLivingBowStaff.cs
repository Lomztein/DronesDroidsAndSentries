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
    public class TinLivingBowStaff : SentryStaff
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a tin living bow that fires at enemies with your own arrows.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 7;
            Item.value = Item.buyPrice(silver: 1, copper: 20);
            Item.rare = ItemRarityID.White;
            Item.buffType = ModContent.BuffType<TinLivingBowBuff>();
            Item.shoot = ModContent.ProjectileType<TinLivingBow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TinBow, 1);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.Topaz, 5);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}
