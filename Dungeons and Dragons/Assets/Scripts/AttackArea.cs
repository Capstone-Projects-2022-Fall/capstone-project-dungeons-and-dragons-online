

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /// <summary>
        /// If the target has EnemyHealth compnent then is triggered
        /// </summary>
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
        }
    }
}
