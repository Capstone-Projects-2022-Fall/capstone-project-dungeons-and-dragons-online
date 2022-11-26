using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
/// <summary>
 /// Handles randomly generating the dungeon recursivly.
/// </summary>
public class AddRoom : MonoBehaviour {

	/// <summary>
    /// Stores the many rooms the dungeon could spawn.
    /// </summary>
	private RoomTemplates templates;
	/// <summary>
    /// When the dungeon is loaded, add an add room object to the scene
    /// </summary>
	void Start(){
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		templates.rooms.Add(this.gameObject);
	}
}
