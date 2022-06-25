using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace DronesDroidsAndSentries
{
    public class Utils
    {
        public static Item GetProjectile(Player player, int ammoType)
        {
            IEnumerable<Item> ammoSlots = new List<Item>()
            {
                player.inventory[54],
                player.inventory[55],
                player.inventory[56],
                player.inventory[57]
            };
            Item fromAmmoSlot = ammoSlots.FirstOrDefault(x => x.stack > 0 && x.active && x.ammo == ammoType);
            if (fromAmmoSlot == null)
            {
                return player.inventory.LastOrDefault(x => x.stack > 0 && x.active && x.ammo == ammoType);
            }
            else return fromAmmoSlot;
        }

        public static void ConsumeAmmo(Item ammoItem)
        {
            // TODO: Handle reduced ammo consumption
            // TODO: Infinite ammo above 3996 in inventory.

            if (ammoItem.maxStack > 1) // This assumes that ammo items with a max stack of 1 is an ammo bag.
            {
                ammoItem.stack--;
            }
        }

        public static Vector2? FindTargetForMinion(Player minionOwner, Projectile minion, ref float targetDist)
        {
            Vector2? targetPos = null;

            // If the player has whipped something, target that.
            if (minionOwner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[minionOwner.MinionAttackTargetNPC];
                if (Collision.CanHitLine(minion.position, 4, 4, npc.position, npc.width, npc.height))
                {
                    targetPos = npc.Center;
                }
            }
            else
            {
                targetPos = FindTarget(minion.position, ref targetDist, x => x.CanBeChasedBy(minion, false));
            }
            return targetPos;
        }

        public static Vector2? FindTarget(Vector2 position, ref float targetDist)
        {
            return FindTarget(position, ref targetDist, x => true);
        }

        public static Vector2? FindTarget(Vector2 position, ref float targetDist, Predicate<NPC> filter)
        {
            Vector2? targetPos = null;

            for (int k = 0; k < 200; k++)
            {
                NPC npc = Main.npc[k];
                if (npc.active && filter(npc))
                {
                    float distance = Vector2.Distance(npc.Center, position);
                    if (distance < targetDist && Collision.CanHitLine(position, 4, 4, npc.position, npc.width, npc.height))
                    {
                        targetDist = distance;
                        targetPos = npc.Center;
                    }
                }
            }

            return targetPos;
        }
    }
}
