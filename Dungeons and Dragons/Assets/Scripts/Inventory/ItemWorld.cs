using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.setItem(item);
        return itemWorld;
    }

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private Item item;
    public void setItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.getSprite();
    }

    public Item getItem()
    {
        return item;
    }

    public void destroyItem()
    {
        Destroy(gameObject);
    }
}
