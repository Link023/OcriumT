using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Weapons
{
    public class SoupLadle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soup Ladle");
            Tooltip.SetDefault("\"I'll give you a taste of ass-whooping!\"");
        }

        public override void SetDefaults()
        {
            // This item has values close to the 'Zombie Arm' (id 1304)
            // It is, however, slightly faster and has a lower base damage.
            item.value = 10000;
            item.melee = true;
            item.damage = 11;
            item.knockBack = 4.25f;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.rare = ItemRarityID.White;
            // Sprite
            item.width = 16;
            item.height = 16;
        }
    }
}