using DronesDroidsAndSentries.Projectiles.Common;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace DronesDroidsAndSentries.Projectiles.Sentries
{
	public abstract class SentryMinion : Minion
	{
		public bool Hovering { get; protected set; } = true;
		public float RecoilForce { get; protected set; } = 10;
		public Vector2 Position { get; protected set; }

		public override void SetDefaults()
		{
			base.SetDefaults();
			Position = Projectile.position;
			Projectile.sentry = true;
			Projectile.minionSlots = 1;
		}

		protected override void Behavior()
		{
			Player player = Main.player[Projectile.owner];
			Projectile.tileCollide = true;
			float targetDist = Range;

			Vector2? targetPos = FindTarget(ref targetDist);

			// idk
			if (Projectile.ai[0] == 1f)
			{
				Projectile.tileCollide = false;
			}

			// Rotate towrads target
			if (targetPos.HasValue && Projectile.ai[0] == 0f)
			{
				Vector2 direction = targetPos.Value - Projectile.position;
				Projectile.rotation = direction.ToRotation();
			}

			// Handle cooldown
			Projectile.ai[1] += 1f;
			bool fire = false;
			if (Projectile.ai[1] > Cooldown)
			{
				Projectile.ai[1] = 0f;
				Projectile.netUpdate = true;
				fire = true;
			}

			// Fire if we have a target
			if (targetPos.HasValue)
			{
				if (fire)
				{
					if (Main.myPlayer == Projectile.owner)
					{
						Vector2 shootVel = targetPos.Value - Projectile.Center;
						if (shootVel == Vector2.Zero)
						{
							shootVel = new Vector2(0f, 1f);
						}
						shootVel.Normalize();
						shootVel *= ShootSpeed;
						Item projectileItem = GetProjectile();
						if (projectileItem != null)
						{
							int proj = Projectile.NewProjectile(Projectile.GetSource_ItemUse_WithPotentialAmmo(projectileItem, projectileItem.shoot), Projectile.position, shootVel, projectileItem.shoot, Projectile.damage + projectileItem.damage, Projectile.knockBack, Main.myPlayer);
							Main.projectile[proj].timeLeft = 300;
							Main.projectile[proj].netUpdate = true;
							Projectile.netUpdate = true;
							ConsumeAmmo(projectileItem);
						}
					}
				}
            }
            else
            {
				Projectile.ai[1] = Cooldown;
            }
		}
	}
}
