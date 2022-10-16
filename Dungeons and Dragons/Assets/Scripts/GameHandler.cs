using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject PlayerPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;
	public GameObject enemyPrefab;
	private float enemyInterval = 3.5f;

	private void Start()
    {
		StartCoroutine(SpawnEnemy(enemyInterval, enemyPrefab));
	}

    private void awake(){
		GameCanvas.SetActive(true);
	}

	public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);

		PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);
	}

	private IEnumerator SpawnEnemy(float interval, GameObject enemy)
	{
		yield return new WaitForSeconds(interval);
		float randVal = Random.Range(-1f,1f);
		Instantiate(enemy, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity);
		StartCoroutine(SpawnEnemy(interval, enemy));
	}
}
