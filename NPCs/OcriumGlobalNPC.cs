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
            // Zombies get a 8 in 30 (=3.75%) chance to drop a soup ladle
            if (npc.type == NPCID.Zombie && Main.rand.Next(30) < 8)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<SoupLadle>(), 1);
            }
            
            // Pass
        }
    }
}