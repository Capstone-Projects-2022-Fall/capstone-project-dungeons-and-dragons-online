using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Health bar handler
/// </summary>
public class Health : MonoBehaviour
{
    /// <summary>
    /// Set the initial health value to 100
    /// </summary>
    [SerializeField] private int health = 100;

    /// <summary>
    /// Set the maximum health value to 100
    /// </summary>
    private int MAX_HEALTH = 100;

    [SerializeField] private HealthBar healthBar;

    // Update is called once per frame
    void Update()
    {
        // Testing Onlys
       /* if (Input.GetKeyDown(KeyCode.O))
         {
             Damage(10);
            // healthBar.SetSize();
            
         }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }*/
    }
    /// <summary>
    /// Damage and health visualization
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
        //Debug.Log((float)(this.health * 0.01 * 1.21f));
        healthBar.SetSize((float)(this.health * 0.01 * 1.21f));
  
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
    /// Calculate the heal
    /// </summary>
    public void Heal(int amount)
    {
        /// <summary>
        /// the damage is negative number will cause an error
        /// </summary>
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have a negative healing");
        }
        StartCoroutine(VisualIndicator(Color.green));

        /// <summary>
        /// If the replenishment exceeds the maximum health value, it stays at the maximum health
        /// </summary>
        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
            healthBar.SetSize((float)(this.health * 0.01 * 1.21f));
        }
    }

    /// <summary>
    /// Destory the player when the health is less then 0
    /// </summary>
    private void Die()
    {
        Debug.Log("dead");
        Destroy(gameObject);
    }
}
