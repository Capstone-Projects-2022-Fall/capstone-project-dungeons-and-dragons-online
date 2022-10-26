using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;
	public GameObject SpawnEnemy;
	public GameObject EnemyPrefab;
	//public GameObject Instance;

	private void Awake(){
		GameCanvas.SetActive(true);
		
	}

	public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);

		PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
	
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);
		SpawnEnemy.SetActive(true);
	}
	/*
	public void SpawnEnemy()
    {
		if (!PhotonNetwork.isMasterClient)
			return;
		float randVal = Random.Range(-1f, 1f);
		//PhotonNetwork.Instantiate(EnemyPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
		randVal = Random.Range(-1f, 1f);
		//PhotonNetwork.Instantiate(EnemyPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
		randVal = Random.Range(-1f, 1f);
		PhotonNetwork.Instantiate(EnemyPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
	}
	*/
}
