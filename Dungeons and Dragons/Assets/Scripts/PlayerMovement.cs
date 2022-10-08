using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Inventory inventory;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private UI_Inventory uiInventory;

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.setInventory(inventory);
        ItemWorld.SpawnItemWorld(new Vector3 (1, 1), new Item {itemType = Item.ItemType.LongSword, amt = 1});
        ItemWorld.SpawnItemWorld(new Vector3 (-1, 1), new Item {itemType = Item.ItemType.HPot, amt = 1});
        ItemWorld.SpawnItemWorld(new Vector3 (0, -1), new Item {itemType = Item.ItemType.RPot, amt = 1});
    }



    private void Start()
    {
        inventory.addItem(new Item {itemType = Item.ItemType.LongSword, amt = 1});
        Debug.Log(inventory);
        healthBar.SetSize(1.21f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.addItem(itemWorld.getItem());
            itemWorld.destroyItem();
        }
    }


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        checkFlipping();
    }

    void checkFlipping()
    {
        // Going left
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(3f, transform.localScale.y);
        }

        // Going right
        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(-3f, transform.localScale.y);
        }
    }

    
}
