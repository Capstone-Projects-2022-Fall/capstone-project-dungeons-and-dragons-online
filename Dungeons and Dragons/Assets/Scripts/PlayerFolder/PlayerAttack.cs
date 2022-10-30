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
    public GameObject attackArea;

    /// Not in attack status
    private bool attacking = false;

    /// Attack time interval
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    public PhotonView photonView;


    /// Get the attack area object from the player
    void Start()
    {
        //attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    /// Attacking type
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //Move();
        if (photonView.IsMine)
        {
            checkAttack();
        }
    }

    void checkAttack()
    {
            // Key J for normal attack the attack status will become ture
            if (Input.GetKeyDown(KeyCode.J))
            {
            //photonView.RPC("Attack", RpcTarget.AllBuffered);
                attacking = true;
                attackArea.SetActive(attacking);
            }

            // Attack status is true then will call the attackArea class to start attacking
            if (attacking)
            {
                timer += Time.deltaTime * 4;

                if (timer >= timeToAttack)
                {
                    timer = 0;
                    attacking = false;
                    attackArea.SetActive(attacking);
                }
            }
    }

}
