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
            for (int type = 0; type < player.buffImmune.Length; type++)
            {
                if (type == Type) continue; // Don't clear itself
                player.buffImmune[type] = true;
            }
            player.immune = true;
        }
    }
}