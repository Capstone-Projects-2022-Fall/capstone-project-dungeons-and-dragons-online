using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;



public class GotoDungeon : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("RandomMap");
        }
        Destroy(gameObject);
    }
}
