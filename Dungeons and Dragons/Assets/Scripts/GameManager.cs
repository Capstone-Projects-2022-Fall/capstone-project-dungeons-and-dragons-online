using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections;

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



	private void Start()
    {
		playersprite = newSkin.GetComponent<SpriteRenderer>().sprite;
		PlayerPrefab.GetComponent<SpriteRenderer>().sprite = playersprite;
		PhotonNetwork.Instantiate(this.pfItemWorld.name, new Vector3(-10f,1f), Quaternion.identity, 0);
		Debug.Log("Instantiated Item World");


	}

    /// <summary>
    /// Displays the game map when the user loads in
    /// </summary>
    private void Awake(){
		GameCanvas.SetActive(true);
		//Debug.Log((int)PhotonNetwork.CurrentRoom.CustomProperties["Seed"]);
		Random.InitState((int)PhotonNetwork.CurrentRoom.CustomProperties["Seed"]);
		
	}

    public void FixedUpdate()
    {

		//Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
		if (Input.GetKeyDown(KeyCode.J))
		{
			StartCoroutine(checkPlayer());
		}
	}

    public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);
		//PlayerPrefab.name
		PhotonNetwork.Instantiate("Player", new Vector2(this.transform.position.x *-0.2f, this.transform.position.y *0.2f), Quaternion.identity, 0);
	
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);

	}

	IEnumerator checkPlayer()
    {
		yield return new WaitForSeconds(5);
		if (SceneManager.GetActiveScene().name == "BattleMap" && PhotonNetwork.CountOfPlayers == 1)
        {
			PhotonNetwork.LoadLevel("VictoryScene");
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
