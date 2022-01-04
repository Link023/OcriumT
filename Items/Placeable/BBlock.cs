using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Placeable
{
    public class BBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("B");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.BBlock>();
        }
    }
}