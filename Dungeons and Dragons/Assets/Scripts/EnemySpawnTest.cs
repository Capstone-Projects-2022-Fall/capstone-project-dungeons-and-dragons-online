using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;

    private float enemyInterval = 3.5f;
    
    void Awake()
    {
        SpawnEnemy(enemyInterval, enemyPrefab);
        //SpawnEnemy(enemyInterval, enemyPrefab2);
    }

    private void SpawnEnemy(float interval, GameObject enemy)
    {
        //yield return new WaitForSeconds(interval);
        float randVal = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(enemy.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
        //StartCoroutine(SpawnEnemy(interval, newEnemy));
    }
 }
