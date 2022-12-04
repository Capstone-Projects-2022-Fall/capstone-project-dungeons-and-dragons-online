using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NextLevelTrigger : MonoBehaviour
{
    public PhotonView pv;
    // Start is called before the first frame update

    private void Awake(){
        int seed = UnityEngine.Random.Range(0, 1000);
        if(PhotonNetwork.IsMasterClient){
            Debug.Log("New Seed " + seed);
            ExitGames.Client.Photon.Hashtable customPropreties = new ExitGames.Client.Photon.Hashtable();
            customPropreties["Seed"] = seed;
            PhotonNetwork.CurrentRoom.SetCustomProperties(customPropreties);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        PhotonNetwork.LoadLevel("RandomMap");
        
    }
}
