using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public void createItemWorld()
    {
        
    }

    public Sprite LongSword;
    public Sprite HPot;
    public Sprite RPot;
    public Sprite G;
    public Sprite Chestplate;
    public Sprite BHelm;
    public Sprite BBoots;
    public Sprite DManPlate;
    public Sprite BORK;
    public Sprite DBlade;
    public Sprite Dagger;
    public Sprite Swifties;
    public Sprite Sallet;
    public Sprite AshenBow;

}
