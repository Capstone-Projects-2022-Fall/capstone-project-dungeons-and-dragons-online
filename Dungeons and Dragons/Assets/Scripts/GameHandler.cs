using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject PlayerPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;

	private void awake(){
		GameCanvas.SetActive(true);
	}

	public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);

		PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);
	}
}
