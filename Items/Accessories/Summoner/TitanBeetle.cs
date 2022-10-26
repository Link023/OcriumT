using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Summoner;

public class TitanBeetle : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("The largest beetle around!");
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
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddTile(TileID.TinkerersWorkbench)
            .AddIngredient(ItemID.HerculesBeetle)
            .AddIngredient(ItemID.BeetleHusk, 8)
            .Register();
    }
}