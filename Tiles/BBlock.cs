using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace OcriumT.Tiles
{
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
}