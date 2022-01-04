using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using OcriumT.Items.Status;

namespace OcriumT.Items.Accessories.Classless {
    public class BloodShield : ModItem
    {
        private int buffDuration = 1200;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Shield");
            Tooltip.SetDefault("Reabsorb the blood lost. Just don't look. Restores 5% of your max HP every second for 10 seconds. Classless.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 2;
            player.allDamage += 8f;

            //item is not on cooldown
            if (player.HasBuff(ModContent.BuffType<ReabsorptionCD>())) return;
            //player health is below 20%
            if (player.statLife >= player.statLifeMax / 5) return;
            //player is not already affected by the buff
            if (player.HasBuff(ModContent.BuffType<Reabsorption>())) return;
            //grant buff
            player.AddBuff(ModContent.BuffType<Reabsorption>(), buffDuration, true);
            //grant cooldown buff
            player.AddBuff(ModContent.BuffType<ReabsorptionCD>(), buffDuration + 18000 + buffDuration);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.CrystalBall);
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}