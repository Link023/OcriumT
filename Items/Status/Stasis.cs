using Terraria;
using Terraria.ModLoader;
using Player = IL.Terraria.Player;

namespace OcriumT.Items.Status
{
    public class Stasis : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stasis");
            Description.SetDefault("No one will hurt you. You will hurt no one.");
        }
    }
}