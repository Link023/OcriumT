using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace OcriumT.Summoner.Shaman;

public class CactusSpiritMinion : AbstractSpiritMinion
{
    public override void SetStaticDefaults()
    {
        // Parent
        base.SetStaticDefaults();

        DisplayName.SetDefault("Cactus Spirit");
        // How many animation frames this has.
        Main.projFrames[Projectile.type] = 1;
    }

    public override void AI()
    {
        Player owner = Main.player[Projectile.owner];

        ActivityCheck<CactusSpiritBuff>(owner);
        Gravity();
        NPC target = SeekOneTarget(owner, 16f);
        if (target != null && Main.rand.NextBool(20))
        {
            Vector2 dir = Vector2.Normalize(Vector2.Subtract(target.Center, Projectile.Center));
            int id = Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.Center.X, Projectile.Center.Y,
                dir.X * 4.6f, dir.Y * 4.6f,
                ProjectileID.RollingCactusSpike,
                (int)(Projectile.damage), 1.1f, Projectile.owner);
            Main.projectile[id].timeLeft = 120; // They only exist for 2 seconds
        }
    }
}

public class CactusSpiritBuff : AbstractSpiritBuff<CactusSpiritMinion>
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        DisplayName.SetDefault("Cactus Spirit");
        Description.SetDefault("This spirit will fight for you.");
    }
}

public class CactusSpiritItem : AbstractSpiritItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cactus Spirit");
        Tooltip.SetDefault("Releases a spirit, imbued with the power of the desert.");
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
        Item.buffType = ModContent.BuffType<CactusSpiritBuff>();
        Item.shoot = ModContent.ProjectileType<CactusSpiritMinion>();
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