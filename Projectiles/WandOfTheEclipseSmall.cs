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
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 29;    // Same as vanilla projectile 522
            projectile.friendly = true;
            projectile.light = 0.8f;
            projectile.magic = true;
        }
        
        public override void AI()
        {
            base.AI();
            // Spawn dust
            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke,
                projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f,
                0, new Color(148, 45, 0));
        }
    }
}