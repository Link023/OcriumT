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
            // Combat
            Projectile.light = 1.0f;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            // Hitbox
            Projectile.width = 18;
            Projectile.height = 18;
            // AI
            Projectile.aiStyle = 29; // Same as vanilla Projectile 521
            Projectile.friendly = true;
        }

        public override void AI()
        {
            base.AI();
            // Spawn dust
            Dust.NewDust(
                Projectile.position,
                Projectile.width, Projectile.height,
                DustID.Smoke,
                Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f,
                0, new Color(195, 64, 7),
                1.4f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Create 6 smaller Projectiles
            for (var i = 0; i < 6; i++)
            {
                SpawnSmallProjectile();
            }

            // Extend with the vanilla behaviour
            return true;
        }

        private void SpawnSmallProjectile()
        {
            // Create a random direction
            double theta = Main.rand.Next(0, 360) * (Math.PI / 180.0); // Random angle in radians
            float dirX = (float)Math.Cos(theta);
            float dirY = (float)Math.Sin(theta);


            int id = Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.position.X, Projectile.position.Y,
                dirX * 1.6f, dirY * 1.6f,
                ModContent.ProjectileType<WandOfTheEclipseSmall>(),
                (int)(Projectile.damage * .5f), 0, Projectile.owner);
            Main.projectile[id].timeLeft = 40; // They only exist for 0.67 seconds
        }
    }
}