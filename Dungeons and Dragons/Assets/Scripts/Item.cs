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
        G
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
        }
    }


}
