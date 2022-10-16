using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enemy movement handler
/// </summary>
public class Enemy : MonoBehaviour
{
    /// Get the chasing object
    private GameObject player;
    public PhotonView photonView;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    /// the speed of the enemy
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    /// <summary>
    /// Getting the distance between enemy and player object
    /// </summary>
    void Update()
    {
        photonView.RPC("findPlayer", PhotonTargets.AllBuffered);
        //findPlayer();
    }

    [PunRPC]
    private void findPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }



}
