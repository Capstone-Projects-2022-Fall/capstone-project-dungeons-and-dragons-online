using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Destroys the items in the game after a player picks them up.
/// </summary>
public class Destroyer : MonoBehaviour
{
    /// <summary>
    /// Timer to keep track of how long an items been on the ground.
    /// </summary>
    float timer = 200;
    /// <summary>
    /// When a player stands on top of the object, it gets destroyed.
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

    }
    
    /// <summary>
    /// If a player doesn't pick up the object and the timer runs out, it gets destroyed.
    /// </summary>
    private void Update()
    {
        timer -= 1;
        print(timer);
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
