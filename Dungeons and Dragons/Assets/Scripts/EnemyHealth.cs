using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy health handler
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Set the initial health value to 100
    /// </summary>
    [SerializeField] private int health = 100;

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
    public void Damage(int amount)
    {
        /// <summary>
        /// the damage is negative number will cause an error
        /// </summary>
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have a negative damage");
        }

        this.health -= amount;

        StartCoroutine(VisualIndicator(Color.red));

        /// <summary>
        /// If amount of health is less than 0 then the player will be destoried
        /// </summary>
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
        Destroy(gameObject);
    }
}
