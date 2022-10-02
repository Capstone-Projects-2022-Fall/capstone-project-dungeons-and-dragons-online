using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Health Potion handler
/// </summary>
public class HealthPotion : MonoBehaviour
{
    /// <summary>
    /// the default heal
    /// </summary>
    private int heal = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If the target has PlayerHealth compnent then is triggered
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Heal(heal);
            Destroy(gameObject);
        }
    }
}
