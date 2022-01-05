using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Status
{
    public class Reabsorption : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blood Rush");
            Description.SetDefault("Rapidly heal back a portion of your health.");
            canBeCleared = false;
        }

        public override void Update(Terraria.Player player, ref int buffIndex)
        {

            if (player.HasBuff(BuffID.Lifeforce))
            {
                player.lifeRegen += player.statLifeMax / 9;
            }
            else
            {
                player.lifeRegen += player.statLifeMax / 10;
            }
           
        }
    }
}