using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


/// <summary>
/// This script sends all players to the dungeon when the collider is crossed.
/// </summary>
public class GotoDungeon : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// Handles sending players to the dungeon when they enter the door for it.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("RandomMap");
        }
        Destroy(gameObject);
    }
}
