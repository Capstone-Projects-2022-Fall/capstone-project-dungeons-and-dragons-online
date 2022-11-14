using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class GotoPVP : MonoBehaviour
{
    public PhotonView photonView;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("BattleMap");
        }
  
        Destroy(gameObject);
    }
}
