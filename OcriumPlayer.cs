using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace OcriumT
{
    public class OcriumPlayer : ModPlayer
    {
        // Do they have space-time displacement?
        public bool spaceTimeDisplacement;
        // What's the animation tick?
        public int spaceTimeDisplacementTick;
        // How long is an animantion?
        public static int spaceTimeDisplacementAnim = 24;

        public override void ResetEffects()
        {
            spaceTimeDisplacement = false;
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            // If we have space-time displacement, but the effect is not on yet ...
            if (spaceTimeDisplacement && !Filters.Scene["SpaceTimeDisplacement"].IsActive())
            {
                // ... turn it on!
                Filters.Scene.Activate("SpaceTimeDisplacement");
            }
            // If we do not have space-time displacement, but the effect is still on ...
            else if(!spaceTimeDisplacement && Filters.Scene["SpaceTimeDisplacement"].IsActive())
            {
                // ... turn it off!
                Filters.Scene.Deactivate("SpaceTimeDisplacement");
            }
        }
    }
}