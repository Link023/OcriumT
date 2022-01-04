using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

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
            player.lifeRegen += player.statLifeMax / 20;
        }
    }
}