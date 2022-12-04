

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

/// <summary>
/// AttackArea handler
/// </summary>
public class AttackArea : MonoBehaviour
{
    
    /// <summary>
    /// the default damage
    /// </summary>
    private int damage = 10;

    /// <summary>
    /// Attack trigger
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If the target has EnemyHealth compnent then is triggered
        if (collider.GetComponent<Health>() != null &&  SceneManager.GetActiveScene().name == "BattleMap")
        {
            Health health = collider.GetComponent<Health>();
            if (collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_2")
            {
                damage = 2;
            }
            health.Damage(damage);
        }
        else if (collider.GetComponent<BOSSHealth>() != null)
        {
            BOSSHealth health = collider.GetComponent<BOSSHealth>();
            if (collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_2")
            {
                damage = 2;
            }
            health.Damage(damage);
        }
        else if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            if (collider.GetComponent<SpriteRenderer>().sprite.name == "skinSelection_2")
            {
                damage = 2;
            }
            health.Damage(damage);
        }


    }

    public int getDamage()
    {
        return damage;
    }
    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }

}
