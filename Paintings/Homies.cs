using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace OcriumT.Paintings
{
    public class HomiesPainting : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.AnchorWall = true;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(
                new EntitySource_TileBreak(i, j),
                i * 16, j * 16,
                48, 48,
                ModContent.ItemType<HomiesItem>());
        }
    }

    public class HomiesItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("'All my homies' by Unknown Artist");
            Tooltip.SetDefault("Fuck Chrome.\nAll my homies use Nintendo 3DS browser.");
        }

        public override void SetDefaults()
        {
            // Placing
            Item.autoReuse = false;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<HomiesPainting>();
            // Sprite
            Item.width = 16;
            Item.height = 16;
            // Misc
            Item.maxStack = 1;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(gold: 1, silver: 4, copper: 50);
        }
    }
}