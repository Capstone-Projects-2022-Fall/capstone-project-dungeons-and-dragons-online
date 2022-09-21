using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distancBetween;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
