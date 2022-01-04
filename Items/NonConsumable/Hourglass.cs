using OcriumT.Items.Status;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace OcriumT.Items.NonConsumable
{
    public class Hourglass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stationary Hourglass");
            Tooltip.SetDefault("Puts you in Stasis for a short time.");
        }
        
        public override void SetDefaults()
        {
            item.value = 10000;
            item.consumable = false;
            item.useAnimation = 90;
            item.UseSound = SoundID.Item79;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTurn = true;
            item.useTime = 90;
            item.maxStack = 1;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Stasis>(), 150, false);
            return true;
        }
    }
}