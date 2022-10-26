using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Summoner;

public class BeetleGlove : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Made from the wings of 30 thousand Satiporoja Beetles");
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
        player.maxMinions += 2;
        Item.autoReuse = true;
        // TODO: add extra summon damage
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddTile(TileID.TinkerersWorkbench)
            .AddIngredient(ModContent.ItemType<TitanBeetle>())
            .AddIngredient(ItemID.TitanGlove)
            .Register();
    }
}