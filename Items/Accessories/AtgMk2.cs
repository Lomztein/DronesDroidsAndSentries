using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace DronesDroidsAndSentries.Items.Accessories
{
    public class AtgMk2 : Accessory
    {
        public const float CHANCE_TO_FIRE = 0.1f;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 30;
            Item.knockBack = 6;
            Item.crit = 4;
            Item.rare = ItemRarityID.Lime;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Atg Mk. 2");
            Tooltip.SetDefault("Safe to use even when there is a chance of downpour.");
        }

        public static bool TryFire(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Random.Shared.NextDouble() < CHANCE_TO_FIRE)
            {
                Console.WriteLine("FIRED ATG MK2 AT " + target.FullName);
                return true;
            }
            return false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<DDSPlayer>().atgMk2 = true;
        }
    }
}
