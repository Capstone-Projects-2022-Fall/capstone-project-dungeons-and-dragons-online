using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PVPManager : MonoBehaviour
{
	public GameObject PlayerPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;

	/// <summary>
	/// Displays the game map when the user loads in
	/// </summary>
	private void Awake()
	{
		GameCanvas.SetActive(true);
	}

	public void Spawnplayer()
	{
		float randVal = Random.Range(-1f, 1f);

		PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * -0.2f, this.transform.position.y * 0.2f), Quaternion.identity, 0);

		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);

		//Debug.Log(this.transform.position.x);

	}
}
