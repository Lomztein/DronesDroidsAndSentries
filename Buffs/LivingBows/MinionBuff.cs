using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace DronesDroidsAndSentries.Buffs.LivingBows
{
    public abstract class MinionBuff<TProjectile> : ModBuff where TProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            DDSPlayer modPlayer = player.GetModPlayer<DDSPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<TProjectile>()] > 0)
            {
                SetMinionStatus(modPlayer, true);
            }
            if (!GetMinionStatus(modPlayer))
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }

        public abstract bool GetMinionStatus(DDSPlayer player);

        public abstract void SetMinionStatus(DDSPlayer player, bool value);
    }
}
