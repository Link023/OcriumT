using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Weapons.Mage;

public class WandOfTheEclipse : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Wand of the Eclipse");
        Tooltip.SetDefault(
            "A weapon imbued with the essence of the eclipse.\nDecreased mana usage during a solar eclipse.");
    }

    public override void SetDefaults()
    {
        // Combat
        Item.DamageType = DamageClass.Magic;
        Item.damage = 67;
        Item.mana = 6;
        Item.knockBack = 5;
        Item.shoot = ModContent.ProjectileType<Projectiles.WandOfTheEclipseLarge>();
        Item.shootSpeed = 17f;
        Item.autoReuse = true;
        Item.useTime = 8;
        // Sprite
        Item.width = 36;
        Item.height = 36;
        // Render
        Item.useAnimation = 8;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.UseSound = SoundID.Item9; // TODO: find a good Item sound
        // Misc
        Item.noMelee = true;
        Item.channel = true;
        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.sellPrice(gold: 1, silver: 30);
    }

    public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
    {
        if (Main.eclipse)
        {
            // Mana usage is reduced by two thirds
            mult = 1f / 3f;
        }
    }
}