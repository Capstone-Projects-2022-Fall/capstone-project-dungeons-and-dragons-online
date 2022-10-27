using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// Player attack handler
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update\
    /// the attackArea object
    private GameObject attackArea = default;

    /// Not in attack status
    private bool attacking = false;

    /// Attack time interval
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private PhotonView photonView;


    /// Get the attack area object from the player
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    /// Attacking type
    void Update()
    {
            
    }

    private void FixedUpdate()
    {
        //Move();
        checkAttack();
    }

    void checkAttack()
    {

            // Key J for normal attack the attack status will become ture
            if (Input.GetKeyDown(KeyCode.J))
            {
            //photonView.RPC("Attack", RpcTarget.AllBuffered);
                attacking = true;
                Attack(attacking);
            }

            // Attack status is true then will call the attackArea class to start attacking
            if (attacking)
            {
                timer += Time.deltaTime * 2;

                if (timer >= timeToAttack)
                {
                    timer = 0;
                    attacking = false;
                    Attack(attacking);
                }
            }
    }

    /// Attack status
    private void Attack(bool attacking)
    {
        attackArea.SetActive(attacking);

    }
    /*
    public void Move()
    {
        //rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (Input.GetAxis("Horizontal") < 0)
        {
            photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
            //FlipFalse();
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
            //FlipTrue();
        }


        //checkFlipping();
        Debug.Log("here");
    }

    [PunRPC]
    void FlipFalse()
    {
        sr.flipX = false;
    }
    [PunRPC]
    void FlipTrue()
    {
        sr.flipX = true;
    }
    */

}
