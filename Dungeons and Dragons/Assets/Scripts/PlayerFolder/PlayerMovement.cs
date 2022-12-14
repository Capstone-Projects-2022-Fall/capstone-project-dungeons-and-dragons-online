using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player movement handler
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// the speed of the character
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// initialize the rigidbody
    /// </summary>
    public Rigidbody2D rb;

    /// <summary>
    /// initialize the moving direction
    /// </summary>
    private Vector2 moveDirection;
 

    /// <summary>
    /// initialize the health bar
    /// </summary>
    [SerializeField] private HealthBar healthBar;

        private void Awake()
        {

        }


    /// <summary>
    /// Update is called once per frame and initialize the health value
    /// </summary>
    private void Start()
    {
        //ItemWorld.SpawnItemWorld(new Vector3(3, -3), new Item{itemType = Item.ItemType.LongSword, amt = 1});
        healthBar.SetSize(1.21f);
    }


    public void increaseSpeed(double amount){
        moveSpeed += (float)amount;
    }

    public float getSpeed()
    {
        return moveSpeed;
    }

    

/// <summary>
/// Update is called once per frame
/// </summary>
void Update()
    {
        ProcessInputs();
    }
    /// <summary>
    /// Update movement
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }
    /// <summary>
    /// Get x, y axis 
    /// </summary>
    void ProcessInputs()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY).normalized; 
    }

    /// <summary>
    /// Relcated the position of the character while moving
    /// </summary>
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        checkFlipping();
    }

    /// <summary>
    /// Relcated the direction of the character
    /// </summary>
    void checkFlipping()
    {
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(3f, transform.localScale.y);
        }

        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(-3f, transform.localScale.y);
        }
    }

    
}
