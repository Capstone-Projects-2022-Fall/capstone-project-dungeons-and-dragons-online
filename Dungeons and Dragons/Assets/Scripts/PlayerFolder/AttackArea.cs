

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
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
