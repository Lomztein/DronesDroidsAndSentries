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
    public class LivingDemonBowStaff : SentryStaff
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons a demonic living bow that fires at enemies with your own arrows.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 14;
            Item.value = Item.buyPrice(silver: 45);
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<LivingDemonBowBuff>();
            Item.shoot = ModContent.ProjectileType<LivingDemonBow>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemonBow, 1);
            recipe.AddIngredient(ItemID.Ebonwood, 8);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
    }
}
