using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Weapons.Shaman
{
    public class TotemOfSparkingBuff : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Totem of Sparking");
            Description.SetDefault("Shoots sparks");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<TotemOfSparkingMinion>()] > 0) {
                player.buffTime[buffIndex] = 18000;
            }
            else {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
    
    public class TotemOfSparkingItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Totem of Sparking");
            Tooltip.SetDefault("Shoots a small spark.\nEnchanted with the magic of the forest.");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults() {
	        item.damage = 30;
	        item.knockBack = 3f;
	        item.mana = 10;
	        item.width = 32;
	        item.height = 32;
	        item.useTime = 36;
	        item.useAnimation = 36;
	        item.useStyle = ItemUseStyleID.HoldingUp;
	        item.value = Item.buyPrice(0, 30, 0, 0);
	        item.rare = ItemRarityID.Cyan;
	        item.UseSound = SoundID.Item44;

	        // These below are needed for a minion weapon
	        item.noMelee = true;
	        item.summon = true;
	        item.buffType = ModContent.BuffType<TotemOfSparkingBuff>();
	        // No buffTime because otherwise the item tooltip would say something like "1 minute duration"
	        item.shoot = ModContent.ProjectileType<TotemOfSparkingMinion>();
        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
	        // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
	        player.AddBuff(item.buffType, 2);

	        // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
	        position = Main.MouseWorld;
	        return true;
        }
    }
    
    // Copied from the tModLoader ExampleMod's ExampleMinion
    public class TotemOfSparkingMinion : ModProjectile
    {
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wand of Sparking");
			// Sets the amount of frames this minion has on its spritesheet
			Main.projFrames[projectile.type] = 1;
			// This is necessary for right-click targeting
			// ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

			// These below are needed for a minion
			// Denotes that this projectile is a pet or minion
			Main.projPet[projectile.type] = true;
			// This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			// Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.tileCollide = true;

			// These below are needed for a minion weapon
			// Only controls if it deals damage to enemies on contact (more on that later)
			projectile.friendly = false;
			// Only determines the damage type
			projectile.minion = true;
			// Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			projectile.minionSlots = 0.5f;
			// Needed so the minion doesn't despawn on collision with enemies or tiles
			projectile.penetrate = -1;
		}

		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles() {
			return false;
		}

		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage() {
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];

			#region Active check
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active || Vector2.Distance(player.Center, projectile.Center) > 2000f) {
				player.ClearBuff(ModContent.BuffType<TotemOfSparkingBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<TotemOfSparkingBuff>())) {
				projectile.timeLeft = 2;
			}
			#endregion

			#region Find target
			// Starting search distance
			Vector2 targetCenter = projectile.Center;
			bool foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			// if (player.HasMinionAttackTargetNPC) {
			// 	NPC npc = Main.npc[player.MinionAttackTargetNPC];
			// 	float between = Vector2.Distance(npc.Center, projectile.Center);
			// 	// Reasonable distance away so it doesn't target across multiple screens
			// 	if (between < 2000f) {
			// 		targetCenter = npc.Center;
			// 		foundTarget = true;
			// 	}
			// }
			// If we have not yet found a player, then find some npc
			
			// This code is required either way, used for finding a target
			for (int i = 0; i < Main.maxNPCs; i++) {
				NPC npc = Main.npc[i];
				if (npc.CanBeChasedBy()) {
					float npcDistance = Vector2.Distance(npc.Center, projectile.Center);
					bool closest = Vector2.Distance(projectile.Center, targetCenter) > npcDistance;

					if (closest || !foundTarget) {
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = npcDistance < 100f;
						bool lineOfSight = Collision.CanHitLine(projectile.Center, projectile.width, projectile.height, npc.position, npc.width, npc.height);

						if (lineOfSight || closeThroughWall)
						{
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			#endregion

			#region Attack
			if (foundTarget) {
				// Minion has a target: attack by shooting it
				if (projectile.frameCounter % 40 == 0)
				{
					Vector2 dir = targetCenter - projectile.Center;
					dir.Normalize();
					dir *= 4f;
					Projectile.NewProjectile(projectile.Center, dir * 2f, 
						ProjectileID.Spark, 14, 8, Main.myPlayer);
					projectile.frameCounter = 0;
				}
			}
			#endregion
			
			#region Gravity
			// Fall to the ground
			float down = projectile.velocity.Y + 2.0f;
			if (down > 8f) down = 8f;
			projectile.velocity = new Vector2(0f, down);
			#endregion

			#region Animation and Visuals
			projectile.frameCounter++;
			#endregion
		}
    }
}