using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Buffs;

public class Stasis : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Statis");
        Description.SetDefault("No one will hurt you. You will hurt no one.");
    }

    public override void Update(Terraria.Player player, ref int buffIndex)
    {
        // For all buffs ...
        for (int type = 0; type < player.buffImmune.Length; type++)
        {
            if (type == Type) continue; // Don't clear stasis
            if (type == ModContent.BuffType<StasisSickness>()) continue; // Don't clear stasis sickness
            if (type == BuffID.PotionSickness) continue; // Don't clear potion sickness
            player.buffImmune[type] = true; // All other buffs are cleared
        }

        player.gravity = 0f; // Player must not be affected by gravity
        player.velocity = new Vector2(0f, 0f); // Player is not allowed to move anywhere
        player.stoned = true; // Player may give new inputs (also sets visuals)
        player.immune = true; // Player is granted I-Frames
    }
}