using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Armor;

[AutoloadEquip(EquipType.Head)]
public class LaughHead : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("The opposite of Cringe.");
    }

    public override void SetDefaults()
    {
        Item.defense = 24;

        Item.width = 18;
        Item.height = 18;

        Item.value = Item.buyPrice(0, 6, 0, 0);
    }

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "trollface.jpg";
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddTile(TileID.WorkBenches)
            .AddIngredient(ItemID.WizardHat)
            .AddIngredient(ItemID.SandBlock, 15)
            .AddIngredient(ItemID.Ectoplasm, 14)
            .Register();
    }
}