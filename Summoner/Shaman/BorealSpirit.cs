using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace OcriumT.Summoner.Shaman;

public class BorealSpiritMinion : AbstractSpiritMinion
{
    public override void SetStaticDefaults()
    {
        // Parent
        base.SetStaticDefaults();

        DisplayName.SetDefault("Boreal Spirit");
        // How many animation frames this has.
        Main.projFrames[Projectile.type] = 1;
    }

    public override void AI()
    {
        Player owner = Main.player[Projectile.owner];

        ActivityCheck<BorealSpiritBuff>(owner);
        Gravity();
        foreach (var target in SeekAllInArea(12.5f))
        {
            target.AddBuff(BuffID.Frostburn, 5);
        }

        Projectile.ai[0] += 0.01f;
        Projectile.ai[1] += 0.018f;
        DustRing(12.5f, 0.1f, DustID.MagicMirror,
            phase: -Projectile.ai[0],
            vel: 2.14f,
            color: Color.LightBlue,
            scale: 1.2f);
        DustRing(12.8f, 0.2f, DustID.Enchanted_Pink,
            phase: Projectile.ai[1] + 1f,
            vel: 2.14f,
            color: Color.SkyBlue,
            scale: 0.7f);
    }
}

public class BorealSpiritBuff : AbstractSpiritBuff<BorealSpiritMinion>
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Boreal Spirit");
        Description.SetDefault("This spirit will fight for you.");
    }
}

public class BorealSpiritItem : AbstractSpiritItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Boreal Spirit");
        Tooltip.SetDefault("Releases a spirit, imbued with the power of the boreal forest.");
    }

    public override void SetDefaults()
    {
        // Parent
        base.SetDefaults();
        // Combat
        Item.damage = 10;
        Item.knockBack = 4;
        // Misc
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 5);
        // Specifics
        Item.buffType = ModContent.BuffType<BorealSpiritBuff>();
        Item.shoot = ModContent.ProjectileType<BorealSpiritMinion>();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type,
        int damage, float knockback)
    {
        player.AddBuff(Item.buffType, 2);
        // TODO: ugly
        position.X = Main.MouseWorld.X;
        position.Y = Main.MouseWorld.Y;
        return true;
    }
}