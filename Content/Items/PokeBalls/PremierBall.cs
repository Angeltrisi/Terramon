﻿using Terramon.Core.Loaders;
using Terramon.Helpers;

namespace Terramon.Content.Items.PokeBalls;

internal class PremierBallProjectile : BasePkballProjectile
{
    protected override int PokeballItem => ModContent.ItemType<PremierBallItem>();
    protected override float CatchModifier => 1;
}

[LoadAfter(typeof(UltraBallMiniItem))]
internal class PremierBallMiniItem : BasePkballMiniItem
{
    protected override int UseRarity => ModContent.RarityType<PremierBallRarity>();
}

[LoadAfter(typeof(UltraBallItem))]
internal class PremierBallItem : BasePkballItem
{
    protected override int UseRarity => ModContent.RarityType<PremierBallRarity>();
    protected override int PokeballThrow => ModContent.ProjectileType<PremierBallProjectile>();
    protected override int PokeballTile => ModContent.TileType<PremierBallTile>();
    protected override int InGamePrice => 200;
}

public class PremierBallTile : BasePkballTile
{
    protected override int DropItem => ModContent.ItemType<PremierBallItem>();
}

public class PremierBallRarity : ModRarity
{
    public override Color RarityColor { get; } = ColorUtils.FromHex(0xC9C9E5);
}