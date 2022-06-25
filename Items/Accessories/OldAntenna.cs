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
    public class OldAntenna : Accessory
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.sellPrice(gold: 1, silver: 90);
            Item.rare = ItemRarityID.Green;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxTurrets += 1;
        }
    }
}
