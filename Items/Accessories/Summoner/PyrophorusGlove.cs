using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Summoner;

public class PyrophorusGlove : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("The fireflies are by your side.");
    }

    public override void SetDefaults()
    {
        // Accessory
        Item.accessory = true;
        // Sprite
        Item.width = 28;
        Item.height = 24;
        // Misc
        Item.rare = ItemRarityID.Lime;
        Item.value = Item.buyPrice(gold: 1);
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        player.maxMinions += 3;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddTile(TileID.TinkerersWorkbench)
            .AddIngredient(ModContent.ItemType<BeetleGlove>())
            .AddIngredient(ItemID.MagmaStone)
            .Register();
    }
}