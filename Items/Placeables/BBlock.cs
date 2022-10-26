using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Placeables;

public class BBlock : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("B");
    }

    public override void SetDefaults()
    {
        // Placing
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.BBlock>();
        // Sprite
        Item.width = 12;
        Item.height = 12;
        // Misc
        Item.maxStack = 999;
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 1, copper: 50);
    }
}