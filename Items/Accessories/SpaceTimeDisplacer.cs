using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories
{
    public class SpaceTimeDisplacer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space-Time Displacer");
            Tooltip.SetDefault("Chance to dodge projectiles!");
        }

        public override void SetDefaults()
        {
            // Sprite
            item.width = 16;
            item.height = 16;
            // Accessory Stats
            item.accessory = true;
            item.rare = ItemRarityID.Lime;
            item.value = 10000;
        }

        public override void UpdateEquip(Player player)
        {
            // Enable space-time displacement on the player
            player.GetModPlayer<OcriumPlayer>().spaceTimeDisplacement = true;
            player.GetModPlayer<OcriumPlayer>().spaceTimeDisplacementTick = OcriumPlayer.spaceTimeDisplacementAnim;
        }
    }
}