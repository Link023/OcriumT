using Terraria;
using Terraria.ModLoader;

namespace OcriumT.Buffs;

public class StasisSickness : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Temporal Fatigue");
        Description.SetDefault("Ignoring space and time is not healthy.");
        
        Main.debuff[Type] = true;
    }

    public override bool RightClick(int buffIndex)
    {
        return false;
    }
}