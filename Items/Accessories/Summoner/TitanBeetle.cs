using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Item = On.Terraria.Item;

namespace OcriumT.Items.Accessories.Summoner
{
    public class TitanBeetle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Beetle");
            Tooltip.SetDefault("The largest beetle around!");
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
            player.maxMinions += 2;
            player.minionKB += 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ItemID.HerculesBeetle, 1);
            recipe.AddIngredient(ItemID.BeetleHelmet, 8);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}