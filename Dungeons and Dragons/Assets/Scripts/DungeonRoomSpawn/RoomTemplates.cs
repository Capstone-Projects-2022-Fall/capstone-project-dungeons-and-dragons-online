using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores rooms that can be spawned and gets rid of any that have spawned so there are no duplicates.
/// </summary>
public class RoomTemplates : MonoBehaviour {

	/// <summary>
	/// Stores bottom rooms.
	/// </summary>
	public GameObject[] bottomRooms;
	/// <summary>
	/// Stores top rooms.
	/// </summary>
	public GameObject[] topRooms;
	/// <summary>
	/// Stores left rooms.
	/// </summary>
	public GameObject[] leftRooms;
	/// <summary>
	/// Stores right rooms.
	/// </summary>
	public GameObject[] rightRooms;
	/// <summary>
	/// Stores a room with no exit.
	/// </summary>
	public GameObject closedRoom;

	/// <summary>
	/// Stores an array of all the rooms that can spawn.
	/// </summary>
	public List<GameObject> rooms;
	/// <summary>
	/// Timer so nothing is overwritten.
	/// </summary>
	public float waitTime;
	/// <summary>
	/// A boolean to see if the boss has been spawned or not.
	/// </summary>
	private bool spawnedBoss;
	/// <summary>
	/// A game object for the boss.
	/// </summary>
	public GameObject boss;

	/// <summary>
	/// Checks to see if any rooms have spawned and if they have to remove them from the list.
	/// This also waits to see if the boss was spawned yet, if not and all rooms have spawned it will spawn it in the last room.
	/// </summary>
	void Update(){
		
		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
