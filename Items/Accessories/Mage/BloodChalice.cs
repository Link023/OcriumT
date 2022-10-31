using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Items.Accessories.Mage;

public class BloodChalice : ModItem
{
    private const string ToolTipDef = "Channels your blood into magical power.\nDon't get greedy.";

    public float Charge = 0;

    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault(ToolTipDef);
    }

    public override void SetDefaults()
    {
        // Kept in inventory
        Item.accessory = false;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useAnimation = 60;
        Item.useTime = 60;
        Item.UseSound = SoundID.DSTMaleHurt;
        Item.useTurn = true;
    }

    public override void UpdateInventory(Player player)
    {
        // Decreases 1 charge each 20 seconds and ensures
        // that charge is never below 0.
        if ((Charge -= 1f / (60f * 20f)) < 0f) Charge = 0f;
        // Set charge to 0 if player is dead.
        if (player.dead) Charge = 0f;

        // Buffs:
        // All the buffs assume use Charge 6 as a target max value
        var step = MathF.Ceiling(Charge * 2.5f) / 2.5f;
        // 1. Additional Mana damage *100% -> *250% quadratic
        player.GetDamage(DamageClass.Magic) *= 1f + step * step * (1.5f / 36f);
        // 2. Additional Mana regen *100%f -> *350f cubic
        player.manaRegenBonus *= (int)MathF.Round(1f + step * step * step * (2.5f / 216f));
        // 3. Reduced armor -0 -> -40 quadratic
        player.statDefense -= (int)MathF.Round(step * step * (40f / 36f));
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        var step = MathF.Ceiling(Charge * 2.5f) / 2.5f;

        tooltips.Add(new TooltipLine(Mod, "InnerVar", $"Charge: {Charge}"));
        tooltips.Add(new TooltipLine(Mod, "InnerVar",
            $"Defense reduction: {(int)MathF.Round(step * step * (40f / 36f))}"));
    }

    public override bool? UseItem(Player player)
    {
        Charge++;
        // Deal damage instantly (stepped):
        var trueCharge = MathF.Ceiling(Charge);
        var dmg = (int)MathF.Round(trueCharge * trueCharge * 30 / 4);
        player.Hurt(
            PlayerDeathReason.ByCustomReason("greed"),
            dmg,
            0
        );
        return true;
    }
}