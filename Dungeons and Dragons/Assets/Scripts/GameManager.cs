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
	private Sprite playersprite;

	int seed = -1;


	private void Start()
    {
		playersprite = newSkin.GetComponent<SpriteRenderer>().sprite;
		PlayerPrefab.GetComponent<SpriteRenderer>().sprite = playersprite;
		
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
		//checkPlayer();
		
    }

    public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);
		//PlayerPrefab.name
		PhotonNetwork.Instantiate("Archer", new Vector2(this.transform.position.x *-0.2f, this.transform.position.y *0.2f), Quaternion.identity, 0);
	
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
	}



}
