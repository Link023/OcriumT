using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OcriumT.Summoner.Shaman;

public abstract class AbstractSpiritMinion : ModProjectile
{
    public override void SetStaticDefaults()
    {
        // Needed for right-click targeting.
        ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

        // This is, in fact, a minion.
        Main.projPet[Projectile.type] = true;
        // This minion can be sacrificed if another is spawned.
        ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
    }

    public override void SetDefaults()
    {
        // Combat
        Projectile.friendly = true;
        Projectile.minion = true;
        Projectile.penetrate = -1;
        Projectile.minionSlots = 1f;
        // Movement
        Projectile.tileCollide = true;
        // Sprite
        Projectile.width = 22;
        Projectile.height = 24;
    }

    public override bool? CanCutTiles()
    {
        return false;
    }

    public override bool MinionContactDamage()
    {
        return false;
    }

    private float AdjustRange(float units)
    {
        return units * 16f;
    }

    #region AI

    protected void ActivityCheck<TBuff>(Player owner) where TBuff : ModBuff
    {
        if (owner.dead || !owner.active)
            owner.ClearBuff(ModContent.BuffType<TBuff>());
        if (owner.HasBuff(ModContent.BuffType<TBuff>()))
            Projectile.timeLeft = 2;
    }

    protected void Gravity()
    {
        Projectile.velocity.Y += 0.1f; // Same as arrows
        // Terminal velocity
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }

    protected NPC SeekOneTarget(Player owner, float maxDist = 700f, bool checkLos = true)
    {
        float d = maxDist;
        Vector2 tgt = Projectile.position;
        bool found = false;


        // First check if the owner has targeted anything
        if (owner.HasMinionAttackTargetNPC)
        {
            NPC dude = Main.npc[owner.MinionAttackTargetNPC];
            float between = Vector2.Distance(dude.Center, Projectile.Center);
            if (between < 2000f)
            {
                d = between;
                tgt = dude.Center;
                found = true;
            }
        }

        // If nothing was targeted explicitly, find the nearest npc
        if (!found)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy())
                {
                    float between = Vector2.Distance(npc.Center, Projectile.Center);
                    bool closest = Vector2.Distance(Projectile.Center, tgt) > between;
                    bool inRange = between < d;
                    bool lineOfSight = !checkLos || Collision.CanHitLine(Projectile.position, Projectile.width,
                        Projectile.height,
                        npc.position, npc.width, npc.height);
                    // Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
                    // The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
                    bool closeThroughWall = between < 100f;
                    if (((closest && inRange) || !found) && (lineOfSight || closeThroughWall))
                    {
                        d = between;
                        tgt = npc.Center;
                        found = true;
                    }
                }
            }
        }

        return null; // TODO: implemenmnejkrth
    }

    protected List<NPC> SeekAllInArea(float range = 20f)
    {
        range = AdjustRange(range);
        List<NPC> targets = new List<NPC>();

        for (int i = 0; i < Main.maxNPCs; i++)
        {
            NPC npc = Main.npc[i];
            if (npc.CanBeChasedBy())
            {
                float between = Vector2.Distance(npc.Center, Projectile.Center);
                if (between <= range)
                {
                    targets.Add(npc);
                }
            }
        }

        return targets;
    }

    protected List<Player> SeekTeam(Player owner, float range)
    {
        range = AdjustRange(range);
        List<Player> team = new List<Player>();

        foreach (var player in Main.player)
        {
            if (player != null
                && (owner.team == 0 || owner.team == player.team)
                && Vector2.Distance(Projectile.Center, player.Center) <= range)
            {
                team.Add(player);
            }
        }

        return team;
    }

    #endregion

    #region Animation

    protected void DustRing(float range, float density, int type,
        float phase = 0f, float vel = 1f,
        int alpha = 0, Color color = default, float scale = 1f)
    {
        var circumference = 2 * MathF.PI * range;
        var dusts = (int)MathF.Round(circumference * density);

        range = AdjustRange(range);

        for (var i = 0; i < dusts; i++)
        {
            var theta = (float)i / dusts * MathF.PI * 2f + phase;
            var pos = new Vector2(MathF.Cos(theta), MathF.Sin(theta)) * range;
            var dpos = new Vector2(-MathF.Sin(theta), MathF.Cos(theta)) * vel;

            Dust d = Dust.NewDustPerfect(
                pos + Projectile.Center,
                type, dpos, alpha, color, scale);
            d.rotation = 0.4f;
        }
    }

    #endregion
}

public abstract class AbstractSpiritBuff<TMinion> : ModBuff where TMinion : AbstractSpiritMinion
{
    public override void SetStaticDefaults()
    {
        Main.buffNoSave[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<TMinion>()] > 0)
        {
            player.buffTime[buffIndex] = 18000;
        }
        else
        {
            player.DelBuff(buffIndex);
            buffIndex--; // ?
        }
    }
}

public abstract class AbstractSpiritItem : ModItem
{
    public override void SetStaticDefaults()
    {
        // Allows the player to target anywhere on screen using a controller.
        ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
        // Does not require targeting something in order to fire.
        ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
    }

    public override void SetDefaults()
    {
        // Combat
        Item.DamageType = DamageClass.Summon;
        Item.mana = 10;
        Item.autoReuse = false;
        Item.useTime = 36;
        // Sprite
        Item.width = 22;
        Item.height = 24;
        // Render
        Item.useAnimation = 36;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item9;
        // Misc
        Item.noMelee = true;
        Item.channel = true;
    }
}