using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Thrower.JackCards
{
    public class JackCardHeart : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hearts");
        }

        public override void SetDefaults()
        {
            projectile.thrown = true;
            projectile.damage = 25;
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
        }
    }
}