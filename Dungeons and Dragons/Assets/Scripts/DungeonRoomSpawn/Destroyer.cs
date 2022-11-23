using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    float timer = 200;
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

    }
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
