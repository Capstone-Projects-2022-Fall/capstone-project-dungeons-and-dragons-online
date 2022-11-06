using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class GotoPVP : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        {
            PhotonNetwork.LoadLevel("BattleMap");
        }
    }
}
