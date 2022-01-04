using Terraria.ModLoader;

namespace OcriumT.Items.Status
{
    public class Stasis : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stasis");
            Description.SetDefault("No one will hurt you. You will hurt no one.");
        }

        public override void Update(Terraria.Player player, ref int buffIndex)
        {
            player.immune = true;
        }
    }
}