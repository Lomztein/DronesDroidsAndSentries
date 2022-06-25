using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries.Items.Accessories
{
    public abstract class Accessory : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory();
        }
    }
}
