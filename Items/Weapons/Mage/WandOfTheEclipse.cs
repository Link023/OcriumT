using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Weapons.Mage
{
    public class WandOfTheEclipse : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A weapon imbued with the essence of the eclipse.\nDecreased mana usage during a solar eclipse.");
        }

        public override void SetDefaults()
        {
            // Combat
            item.damage = 67;
            item.magic = true;
            item.mana = 6;
            item.knockBack = 5;
            item.shoot = ModContent.ProjectileType<Projectiles.WandOfTheEclipseLarge>();
            item.shootSpeed = 17f;
            // Sprite
            item.width = 36;
            item.height = 36;
            // Animation
            item.autoReuse = true;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            // Misc
            item.noMelee = true;
            item.channel = true;
            item.value = Item.sellPrice(gold: 1, silver: 30);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item9;      // TODO: find a good item sound
        }

        public override void ModifyManaCost(Player player, ref float reduce, ref float mult)
        {
            if (Main.eclipse)
            {
                // Mana usage is reduced by two thirds
                mult = 1f/3f;
            }
        }
    }
}