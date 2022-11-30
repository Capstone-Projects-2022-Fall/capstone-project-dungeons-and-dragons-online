

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
    public SpriteRenderer sr;
    public PhotonView photonView;
    /// <summary>
    /// Attack trigger
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // If the target has EnemyHealth compnent then is triggered
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            if (sr.sprite.name == "skinSelection_2")
            {
                damage = 2;
            }
            photonView.RPC("health.Damage", RpcTarget.AllBuffered, damage);
        }
       
    }
}
