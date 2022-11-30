using UnityEngine;
/// <summary>
/// AttackArea handler
/// </summary>
public class BOSSAttackArea : MonoBehaviour
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
        // If the target has PlayerHealth compnent then is triggered
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
