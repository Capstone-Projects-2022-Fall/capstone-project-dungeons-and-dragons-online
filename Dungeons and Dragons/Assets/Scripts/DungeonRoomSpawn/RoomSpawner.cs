using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

/// <summary>
/// This handles which room is selected to spawn randomly
/// </summary>

public class RoomSpawner : MonoBehaviourPun {
	/// <summary>
	/// Stores where the room has a door too.
	/// </summary>
	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door

	/// <summary>
	/// Holds the template for the rooms that can spawn.
	/// </summary>
	private RoomTemplates templates;
	/// <summary>
	/// Random number to determine what room gets spawned
	/// </summary>
	private int rand;
	/// <summary>
	/// Then if the room gets spawned, there is a boolean to signal it.
	/// </summary>
	public bool spawned = false;

	/// <summary>
	/// A 4 millisecond timer so rooms don't spawn twice.
	/// </summary>
	public float waitTime = 4f;


	/// <summary>
	/// Finds the dungeon game object on start up.
	/// </summary>
	void Start(){
		Destroy(gameObject, waitTime);
		PhotonView photonView = PhotonView.Get(this);
		
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
		//photonView.PRC("",___);
	}

	/// <summary>
	/// Spawns a room in the direction that is needed.
	/// </summary>

	void Spawn(){
		if(spawned == false){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
			}
			//Debug.Log(rand);
			spawned = true;
		}
	}

	/// <summary>
	///Handles the spawn point for the first room of the dungeon.
	/// </summary>
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		}
	}


}
