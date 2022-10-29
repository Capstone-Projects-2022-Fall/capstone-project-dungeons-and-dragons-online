using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
	//This is the player object that will spawn for each player to control
    public GameObject PlayerPrefab;
	//Tilemap
	
	public GameObject GameCanvas;
	//Main camera
	public GameObject SceneCamera;

	public GameObject pfItemWorld;
	
	/// <summary>
	/// Displays the game map when the user loads in
	/// </summary>
	private void Awake(){
		GameCanvas.SetActive(true);
		
	}

	/// <summary>
	/// Spawns a player prefab for each player that joins
	/// </summary>
	public void SpawnPlayer(){
		//Get a random float used for the spawn location
		float randVal = Random.Range(-1f,1f);

		//Spawn a character and give them a random location to spawn to on the map
		PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);

	
		GameCanvas.SetActive(false);
		//Turn off the main camera to so the player sees out of their own
		SceneCamera.SetActive(false);

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
}
