using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Summoner
{
    public class BeetleGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Glove");
            Tooltip.SetDefault("Made from the wings of 30 thousand Satiporoja Beetles");
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
            player.minionKB += 6f;
            item.autoReuse = true;
            //add extra summon damage
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(mod, "TitanBeetle");
            recipe.AddIngredient(ItemID.TitanGlove);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
    
}