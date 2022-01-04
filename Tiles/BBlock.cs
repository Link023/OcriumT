using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace OcriumT.Tiles
{
    public class BBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            drop = ModContent.ItemType<Items.Placeable.BBlock>();
            AddMapEntry(new Color(255, 0, 0));
        }
    }
}