﻿using Terramon.Core.Loaders;
using Terraria.GameContent.Creative;

namespace Terramon.Content.Items;

[AutoloadEquip(EquipType.Body)]
[LoadGroup("TrainerVanity")]
[LoadWeight(1f)] // After TrainerCap (0f)
public class TrainerTorso : VanityItem
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        Item.width = 18;
        Item.height = 18;
        Item.value = 3000;
        Item.maxStack = 1;
        Item.rare = ItemRarityID.White;
        Item.vanity = true;
    }
}