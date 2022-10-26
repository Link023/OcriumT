using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Tiles;

public class BBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = false;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = false;
        AddMapEntry(new Color(255, 0, 0));
    }

    public override bool Drop(int i, int j)
    {
        return true;
    }
}

public class BBlockItem : ModItem
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
        Item.createTile = ModContent.TileType<BBlock>();
        // Sprite
        Item.width = 12;
        Item.height = 12;
        // Misc
        Item.maxStack = 999;
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 1, copper: 50);
    }
}