using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories
{
    public class PyrophorusGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pyrophorus Glove");
            Tooltip.SetDefault("The fireflies are by your side.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 28;
            item.height = 24;
            item.rare = ItemRarityID.Lime;
            item.value = 10000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 3;
            player.minionKB += 7f;
            player.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(mod, "BeetleGlove");
            recipe.AddIngredient(ItemID.MagmaStone);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}