using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Weapons;

public class SoupLadle : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("\"I'll give you a taste of ass-whooping!\"");
    }

    public override void SetDefaults()
    {
        // This item has values close to the 'Zombie Arm' (id 1304)
        // It is, however, slightly faster and has a lower base damage.
        // Moreover, the hitbox is a bit thinner, which means that enemies
        // who are close-by have a larger chance of hitting you before you get them.

        // Combat
        Item.DamageType = DamageClass.Melee;
        Item.damage = 11;
        Item.knockBack = 4.25f;
        Item.useTime = 20;
        // Hitbox
        Item.width = 20;
        Item.height = 28;
        // Render
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;
        // Misc
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0,0,10,50);
    }
}