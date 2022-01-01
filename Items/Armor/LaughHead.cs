using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace OcriumT.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class LaughHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The opposite of cringe.");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 60000;
            item.rare = ItemRarityID.Cyan;
            item.defense = 24;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "trollface.jpg";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.WizardHat);
            recipe.AddIngredient(ItemID.SandBlock, 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 14);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}