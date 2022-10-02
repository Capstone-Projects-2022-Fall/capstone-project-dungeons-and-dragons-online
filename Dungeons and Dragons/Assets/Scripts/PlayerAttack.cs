using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player attack handler
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update\
    /// <summary>
    /// the attackArea object
    /// </summary>
    private GameObject attackArea = default;

    /// <summary>
    /// Not in attack status
    /// </summary>
    private bool attacking = false;

    /// <summary>
    /// Attack time interval
    /// </summary>
    private float timeToAttack = 0.25f;
    private float timer = 0f;


    /// <summary>
    /// Get the attack area object from the player
    /// </summary>
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    /// <summary>
    /// Attacking type
    /// </summary>
    void Update()
    {

        /// <summary>
        /// Key J for normal attack the attack status will become ture
        /// </summary>
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }

        /// <summary>
        /// Attack status is true then will call the attackArea class to start attacking
        /// </summary>
        if (attacking)
        {
            timer += Time.deltaTime * 2;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    /// <summary>
    /// Attack status
    /// </summary>
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
