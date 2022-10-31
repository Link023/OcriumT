using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace OcriumT.Tiles.Totem;

public class BasicTotem : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileFrameImportant[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.AnchorWall = false;
        TileObjectData.addTile(Type);
        DustType = 7;

        AddMapEntry(new Color(114, 81, 56));
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(new EntitySource_TileBreak(i * 16, j * 16), i * 16, j * 16, 48, 48,
            ModContent.ItemType<BasicTotemItem>());
    }
}

public class BasicTotemItem : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 24;
        Item.maxStack = 99;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.consumable = true;
        Item.value = Item.sellPrice(silver: 4, copper: 75);
        Item.rare = ItemRarityID.White;
        Item.createTile = ModContent.TileType<BasicTotem>();
        // Item.placeStyle = 1;
    }
}