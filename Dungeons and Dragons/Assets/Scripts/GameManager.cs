using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//This is the player object that will spawn for each player to control
    public GameObject PlayerPrefab;
	//Tilemap
	public GameObject GameCanvas;
	//Main camera
	public GameObject SceneCamera;
	
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
	}
}
