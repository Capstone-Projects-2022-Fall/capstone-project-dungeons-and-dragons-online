using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        LongSword,
        HPot,
        RPot,
        G,
        Chestplate,
        BHelm,
        BBoots,
        DManPlate,
        BORK,
        DBlade,
        Dagger,
        Swifties,
        Sallet,
        AshenBow

    }

    public ItemType itemType;
    public int amt;

    public Sprite getSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.LongSword: return ItemAssets.Instance.LongSword;
            case ItemType.HPot: return ItemAssets.Instance.HPot;
            case ItemType.RPot: return ItemAssets.Instance.RPot;
            case ItemType.G: return ItemAssets.Instance.G;
            case ItemType.Chestplate: return ItemAssets.Instance.Chestplate;
            case ItemType.BHelm: return ItemAssets.Instance.BHelm;
            case ItemType.BBoots: return ItemAssets.Instance.BBoots;
            case ItemType.DManPlate: return ItemAssets.Instance.DManPlate;
            case ItemType.BORK: return ItemAssets.Instance.BORK;
            case ItemType.DBlade: return ItemAssets.Instance.DBlade;
            case ItemType.Dagger: return ItemAssets.Instance.Dagger;
            case ItemType.Swifties: return ItemAssets.Instance.Swifties;
            case ItemType.Sallet: return ItemAssets.Instance.Sallet;
            case ItemType.AshenBow: return ItemAssets.Instance.AshenBow;
        }
    }


}
