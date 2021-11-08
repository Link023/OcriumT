using IL.Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items
{
    public class Hourglass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stationary Hourglass");
            Tooltip.SetDefault("Puts you in Stasis for a short time.");
        }

        public override void SetDefaults()
        {
            item.value = 10000;
            item.consumable = false;
            item.useTime = 100;
            item.maxStack = 1;

        }
    }
}