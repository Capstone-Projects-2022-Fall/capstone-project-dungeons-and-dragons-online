using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviour
{
	public GameObject PlayerPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;
    public GameObject newSkin;
	public GameObject pfItemWorld;
	private Sprite playersprite;
	private RoomInfo ri;
	int seed = -1;

	private int maximumPlayer = 0;

	private void Start()
    {
		PhotonNetwork.Instantiate(this.pfItemWorld.name, new Vector3(-10f,1f), Quaternion.identity, 0);
		Debug.Log("Instantiated Item World");
    }

    /// <summary>
    /// Displays the game map when the user loads in
    /// </summary>
    private void Awake(){
		GameCanvas.SetActive(true);
		Debug.Log((int)PhotonNetwork.CurrentRoom.CustomProperties["Seed"]);
		Random.InitState((int)PhotonNetwork.CurrentRoom.CustomProperties["Seed"]);
		
	}

    public void FixedUpdate()
    {
		checkPlayer();
		//print("Current players" + ri.PlayerCount);
		//checkWinning();

	}

    public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);
		//PlayerPrefab.name
		PhotonNetwork.Instantiate("Player", new Vector2(this.transform.position.x *-0.2f, this.transform.position.y *0.2f), Quaternion.identity, 0);
	
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);

		//Debug.Log(this.transform.position.x);

		// ItemWorld inst = ItemWorld.SpawnItemWorld(new Vector3(3, -3), new Item{itemType = Item.ItemType.LongSword, amt = 1});
		// phItemWorld(inst);
	}

	public void phItemWorld(ItemWorld i)
	{
		// float randVal = Random.Range(-1f,1f);
		// Instantiate(i, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity);
        // ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        // itemWorld.setItem(item);
        // return itemWorld;

	}

	public void checkPlayer()
    {
		Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
        if (maximumPlayer < PhotonNetwork.CountOfPlayers)
        {
			maximumPlayer = PhotonNetwork.CountOfPlayers;
		}


		//Win condition in PVP
        if (PhotonNetwork.CountOfPlayers == 1 && SceneManager.GetActiveScene().name == "BattleMap")
        {
			Debug.Log("You win");
			PhotonNetwork.LoadLevel("LoseScene");
		}

		//Lose condition in D
		if (PhotonNetwork.CountOfPlayers == 0 && SceneManager.GetActiveScene().name == "RandomMap")
		{
			Debug.Log("Lose");
			PhotonNetwork.LoadLevel("MainGame");
		}

        //Reload the game when players come back
        if (maximumPlayer < PhotonNetwork.CountOfPlayers && SceneManager.GetActiveScene().name == "RandomMap")
        {
			PhotonNetwork.LoadLevel("RandomMap");
		}
	}

	/*public void checkWinning()
    {
		if(ri.PlayerCount == 0)
        {
			print("all players die");
			PhotonNetwork.LoadLevel("VictoryScene");
        }
    }*/


}
