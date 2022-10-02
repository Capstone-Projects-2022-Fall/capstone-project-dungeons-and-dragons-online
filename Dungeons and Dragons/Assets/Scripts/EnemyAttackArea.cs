using UnityEngine;
/// <summary>
/// AttackArea handler
/// </summary>
public class EnemyAttackArea : MonoBehaviour
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
        /// If the target has PlayerHealth compnent then is triggered
        /// </summary>
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
