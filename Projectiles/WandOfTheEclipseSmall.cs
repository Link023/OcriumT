using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Projectiles
{
    public class WandOfTheEclipseSmall : ModProjectile
    {
        public override void SetDefaults()
        {
            // Combat
            Projectile.light = 0.8f;
            Projectile.DamageType = DamageClass.Magic;
            // Hitbox
            Projectile.width = 12;
            Projectile.height = 12;
            // AI
            Projectile.aiStyle = 29;    // Same as vanilla Projectile 522
            Projectile.friendly = true;
        }

        public override void AI()
        {
            base.AI();
            // Spawn dust
            Dust.NewDust(Projectile.position,
                Projectile.width, Projectile.height,
                DustID.Smoke,
                Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f,
                0, new Color(148, 45, 0));
        }
    }
}