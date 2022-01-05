using Terraria;
using Terraria.ModLoader;

namespace OcriumT.Items.Status
{
    public class ReabsorptionCD : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blood Recovery");
            Description.SetDefault("You must recover from reabsorbing your blood.");
            canBeCleared = false;
            Main.debuff[Type] = true;
            longerExpertDebuff = false;
        }
    }
}