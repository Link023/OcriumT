using System;
using OcriumT.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.NPCs
{
    public class OcriumGlobalNpc : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            // Zombies get a 1 in 40 (=2.5%) chance to drop a soup ladle
            if (npc.type == NPCID.Zombie && Main.rand.Next(40) == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<SoupLadle>(), 1);
            }
            
            // Pass
        }
    }
}