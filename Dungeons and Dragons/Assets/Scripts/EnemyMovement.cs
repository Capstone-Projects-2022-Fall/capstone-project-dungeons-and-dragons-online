using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy movement handler
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Get the chasing object
    /// </summary>
    public GameObject player;

    /// <summary>
    /// the speed of the enemy
    /// </summary>
    public float speed;

    /// <summary>
    /// the chasing distance detector 
    /// </summary>
    public float distancBetween;

    /// <summary>
    /// the distance between the enemy and player
    /// </summary>
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Getting the distance between enemy and player object
    /// </summary>
    void Update()
    {
        // Getting the distance between enemy and player object
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        
        direction.Normalize();
        checkFlipping(direction);
        //float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;

        if(distance < distancBetween){
             // Keep updating the movement
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
          //  transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    /// <summary>
    /// Relcated the direction of the enemy
    /// </summary>
    void checkFlipping(Vector2 direction)
    {
        // Going left
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(3f, transform.localScale.y);
        }

        // Going right
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-3f, transform.localScale.y);
        }
    }
}
