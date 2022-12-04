using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = System.Random;

/// <summary>
/// Enemy health handler
/// </summary>
public class EnemyHealth : MonoBehaviour
{

    public GameObject attackArea;
    /// <summary>
    /// Set the initial health value to 10
    /// </summary>
    [SerializeField] private int health = 10;
    public GameObject dropItem;

    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        // Testing Onlys
        if (Input.GetKeyDown(KeyCode.O))
          {
              Damage(10);
             // healthBar.SetSize();

          }

    }

    /// <summary>
    /// Damage visualization
    /// </summary>
    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    /// <summary>
    /// Calculate the damage
    /// </summary>
    /// <includesource>
    /// ArgumentOutOfRangeException
    /// </includesource>
    public void Damage(int amount) 
    {
        // the damage is negative number will cause an error
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have a negative damage");
        }

        this.health -= amount;

        StartCoroutine(VisualIndicator(Color.red));

        // If amount of health is less than 0 then the player will be destoried
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Destory the enemy when the health is less then 0
    /// </summary>
    private void Die()
    {
        Debug.Log("dead");
        // PhotonNetwork.Instantiate(dropItem.name, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        // ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.LongSword, amt = 1});
        spawnItem();
        Destroy(gameObject);
    }

    public void spawnItem()
    {
        //player base stats: HP = 100, dmg = 10, move speed = 5
        Random r = new Random();
        int rInt = r.Next(0, 50);
        switch(rInt)
        {
            case(0):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.LongSword, amt = 1});
                //attackArea.setDamage(attackArea.getDamage() * 1);
                
                //no change to player damage
                break;
            case(1):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.HPot, amt = 1});
                player.GetComponent<Health>().Heal(25);
                //increase health by 25
                break;
            case(2):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.RPot, amt = 1});
                player.GetComponent<Health>().Heal(100);
                //increase health by 100
                break;
            case(3):
                //ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.G, amt = 1});
                
                //do nothing since we didnt implement money
                break;
            case(4):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.Chestplate, amt = 1});
                if (player.GetComponent<Health>().getHP < 200){
                    player.GetComponent<Health>().HPincrease(80);
                }
                //if player has less than 200hp, increase hp by 80
                break;
            case(5):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.BHelm, amt = 1});
                if (player.GetComponent<Health>().getHP < 200){
                    player.GetComponent<Health>().HPincrease(20);
                }
                //if player has less than 200hp, increase hp by 20
                break;
            case(6):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.BBoots, amt = 1});
                player.GetComponent<PlayerMovement>().increaseSpeed(.01);
                //increase player move speed by .01
                break;
            case(7):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.DManPlate, amt = 1});
                player.GetComponent<Health>().Heal(40);
                player.GetComponent<PlayerMovement>().increaseSpeed(.1);
                //increase player move speed by .1, and increase health by 40
                break;
            case(8):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.BORK, amt = 1});
                int damage =player.GetComponent<AttackArea>().getDamage();
                player.GetComponent<AttackArea>().setDamage(damage+1);
                //increase player damage by *1.3, take floor
                break;
            case(9):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.DBlade, amt = 1});
                int damage =player.GetComponent<AttackArea>().getDamage();
                player.GetComponent<AttackArea>().setDamage(damage+1);
                //increase player damage by +1
                break;
            case(10):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.Dagger, amt = 1});
                player.GetComponent<PlayerMovement>().increaseSpeed(.05);
                int damage =player.GetComponent<AttackArea>().getDamage();
                player.GetComponent<AttackArea>().setDamage(damage+1);
                //increase player damage by +1, increase player speed by 0.05
                break;
            case(11):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.Swifties, amt = 1});
                player.GetComponent<PlayerMovement>().increaseSpeed(.4);
                //increase player speed by 0.4
                break;
            case(12):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.Sallet, amt = 1});
                player.GetComponent<Health>().Heal(20);
                //increase player health by 20
                break;
            case(13):
                ItemWorld.SpawnItemWorld(new Vector3 (this.transform.position.x, this.transform.position.y), new Item {itemType = Item.ItemType.AshenBow, amt = 1});
                int damage =player.GetComponent<AttackArea>().getDamage();
                player.GetComponent<AttackArea>().setDamage(damage+1);
                //increase player damage by +1
                break;
            default:
                Debug.Log(rInt);
                return;
        }
    }
}
