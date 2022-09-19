using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] private HealthBar healthBar;


    private void Start()
    {
        healthBar.SetSize(.4f);

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
