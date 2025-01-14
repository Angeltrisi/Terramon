﻿using Terramon.Content.NPCs.Pokemon;
using Terramon.Core.NPCComponents;

// ReSharper disable UnassignedField.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global

namespace Terramon.Content.NPCs;

/// <summary>
///     A <see cref="NPCComponent" /> to control the visual behaviour of Pokémon NPCs.
/// </summary>
public class NPCVisuals : NPCComponent
{
    public Vector3 LightColor = Vector3.One;
    public float LightStrength = 0f;
    public float DamperAmount = 0; //0 = no effect, 1 = full effect

    public int DustID = -1;
    public float DustFrequency = 20;//how many frames until dust is spawned
    public float DustOffsetX = 0;
    public float DustOffsetY = 0;

    private float _dustTimer;

    public override void AI(NPC npc)
    {
        base.AI(npc);
        
        if (!Enabled || ((PokemonNPC)npc.ModNPC).PlasmaState) return;

        if (LightStrength > 0)
            Lighting.AddLight(npc.Center, LightColor * LightStrength * (Main.raining || npc.wet ? 1 - DamperAmount : 1));

        if (DustID <= -1) return;
        if (_dustTimer >= DustFrequency)
        {
            Dust.NewDust(npc.position + new Vector2(npc.spriteDirection == 1 ? npc.width - DustOffsetX : DustOffsetX, DustOffsetY), 1, 1, DustID);
            _dustTimer = 0;
        }
        else
            _dustTimer++;
    }
}