using Microsoft.Xna.Framework;
using OcriumT.Items.Accessories.Thrower.JackCards;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Thrower
{
    public class JackCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jack of all Trades");
            Tooltip.SetDefault("Each suit has a different effect.");
        }

        public override void SetDefaults()
        {
            item.thrown = true;
            item.consumable = false;
            item.rare = ItemRarityID.Blue;
            item.value = 10000;
            item.shoot = mod.ProjectileType("JackCardHeart");
            item.shootSpeed = 12f;
        }
    }
}