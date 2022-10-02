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

    /// <summary>
    /// Update is called once per frame and initialize the health value
    /// </summary>
    private void Start()
    {
        healthBar.SetSize(1.21f);

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
    /// <c>
    ///         if (moveDirection.x < 0)
    ///    {
    ///        transform.localScale = new Vector3(3f, transform.localScale.y);
    ///    }
    /// </c>
    /// </summary>
    void checkFlipping()
    {
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(3f, transform.localScale.y);
        }

        /// <summary>
        /// Moving to the right and localScale.x will be set to negative
        /// </summary>
        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(-3f, transform.localScale.y);
        }
    }
}
