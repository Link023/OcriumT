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
            // Moreover, the hitbox is a bit thinner, which means that enemies
            // who are close-by have a larger chance of hitting you before you get them.
            
            item.value = 10000;
            item.melee = true;
            item.damage = 11;
            item.knockBack = 4.25f;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.rare = ItemRarityID.White;
            // Hitbox
            item.width = 20;
            item.height = 28;
        }
    }
}