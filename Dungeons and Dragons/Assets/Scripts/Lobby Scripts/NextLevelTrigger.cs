using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NextLevelTrigger : MonoBehaviour
{
    public PhotonView pv;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PhotonNetwork.LoadLevel("RandomMap");
    }
}
