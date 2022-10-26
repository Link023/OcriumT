using OcriumT.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.NonConsumable;

public class Hourglass : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stationary Hourglass");
        Tooltip.SetDefault("Puts you in Statis for a short time.");
    }

    public override void SetDefaults()
    {
        // Usage
        Item.consumable = false;
        Item.useTime = 90;
        Item.useTurn = true;
        // Render
        Item.useAnimation = 90;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.UseSound = SoundID.Item4;
        // Misc
        Item.maxStack = 1;
        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.buyPrice(0, 1, 0, 0);
    }

    public override bool CanUseItem(Player player)
    {
        return !player.HasBuff(ModContent.BuffType<StasisSickness>());
    }

    public override bool? UseItem(Player player)
    {
        player.AddBuff(ModContent.BuffType<Stasis>(), 150, false);
        player.AddBuff(ModContent.BuffType<StasisSickness>(), 7200 + 150, false);
        player.AddBuff(BuffID.PotionSickness, 1800 + 150);
        return true;
    }
}