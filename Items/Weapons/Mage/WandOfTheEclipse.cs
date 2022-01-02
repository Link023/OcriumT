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
            item.damage = 62;
            item.magic = true;
            item.mana = 30;
            item.knockBack = 5;
            item.shoot = ProjectileID.CrystalPulse; // TODO: Create a custom projectile
            item.shootSpeed = 10f;
            // Sprite
            item.width = 36;
            item.height = 36;
            // Animation
            item.useTime = 28;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
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
                // Mana usage is reduced by 67%
                mult = 1f/3f;
            }
        }
    }
}