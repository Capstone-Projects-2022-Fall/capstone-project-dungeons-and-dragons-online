using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

/// <summary>
 /// Handles sending players to the PVP areana.
 /// </summary>
public class GotoPVP : MonoBehaviour
{
    public PhotonView photonView;
    /// <summary>
    /// Handles sending players to the pvp areana when they enter the door for it.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CountOfPlayers >= 2)
        {
            PhotonNetwork.LoadLevel("BattleMap");
        }
  
        Destroy(gameObject);
    }
}
