using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

/// <summary>
/// Enemy movement handler
/// </summary>
public class BOSSMovement : MonoBehaviour
{
    /// Get the chasing object
    private GameObject[] otherPlayers;
    public PhotonView pv;

    /// the speed of the enemy
    public float speed;

    /// the chasing distance detector 

    //public float distancBetween;

    /// the distance between the enemy and player

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Getting the distance between enemy and player object
    /// </summary>
    void FixedUpdate()
    {
        // Getting the distance between enemy and player object
        /*distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        
        direction.Normalize();
        checkFlipping(direction);
        //float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;

        if(distance < distancBetween){
             // Keep updating the movement
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
          //  transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }*/
        pv.RPC("findPlayer", RpcTarget.AllBuffered);
        findPlayer();
    }

    [PunRPC]
    private void findPlayer()
    {
        otherPlayers = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < otherPlayers.Length; i++)
        {
            float tempx = otherPlayers[i].transform.position.x-transform.position.x;
            float tempy = otherPlayers[i].transform.position.y-transform.position.y;
            if (!(tempx>5.2 || tempx < -5.2 || tempy < -5.2 || tempy > 5.2)) 
            {
                Debug.Log("x" + tempx);
                Debug.Log("y" + tempy);
                this.transform.position = Vector2.MoveTowards(transform.position, otherPlayers[i].transform.position, speed * Time.deltaTime);
            }
            
        }
    }

    /// <summary>
    /// Relcated the direction of the enemy
    /// </summary>
    void checkFlipping(Vector2 direction)
    {
        // Going left
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(3f, transform.localScale.y);
        }

        // Going right
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-3f, transform.localScale.y);
        }
    }
}
