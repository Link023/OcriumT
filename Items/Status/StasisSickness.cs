using Terraria;
using Terraria.ModLoader;

namespace OcriumT.Items.Status
{
    public class StasisSickness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Temporal Fatigue");
            Description.SetDefault("Ignoring space and time is not healthy.");
            canBeCleared = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }
    }
}