using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace OcriumT.Projectiles
{
    public class WandOfTheEclipseLarge : ModProjectile
    {
        public override void SetDefaults()
        {
            // Sprite
            projectile.width = 18;
            projectile.height = 18;
            // AI
            projectile.aiStyle = 29;    // Same as vanilla projectile 521
            projectile.friendly = true;
            // Combat
            projectile.light = 1.0f;
            projectile.magic = true;
            projectile.penetrate = 1;
        }

        public override void AI()
        {
            base.AI();
            // Spawn dust
            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke,
                projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f,
                0, new Color(195, 64, 7), 1.4f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Create 6 smaller projectiles
            for (int i = 0; i < 6; i++)
            {
                SpawnSmallProjectile();
            }
            // Extend with the vanilla behaviour
            return true;
        }
        private void SpawnSmallProjectile()
        {
            // Create a random direction
            double theta = Main.rand.Next(0, 360) * (Math.PI / 180.0);  // Random angle in radians
            float dirX = (float) Math.Cos(theta);
            float dirY = (float) Math.Sin(theta);
            
            int id = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y,
                dirX * 1.6f, dirY * 1.6f,
                ModContent.ProjectileType<WandOfTheEclipseSmall>(), 
                (int)(projectile.damage * .5f), 0, projectile.owner);
            Main.projectile[id].timeLeft = 40; // They only exist for 0.67 seconds
        }
    }
}