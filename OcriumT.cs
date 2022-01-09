using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT
{
	public class OcriumT : Mod
	{
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				// Load shaders ...
				Ref<Effect> displacementEffect = new Ref<Effect>(GetEffect("Effects/STD"));
				Filters.Scene["SpaceTimeDisplacement"] =
					new Filter(new ScreenShaderData(displacementEffect, "FilterSTD"), EffectPriority.Medium);
				Filters.Scene["SpaceTimeDisplacement"].Load();
			}
		}
	}
}