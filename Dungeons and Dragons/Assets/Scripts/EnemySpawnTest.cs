using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject enemyPrefab2;
    private float enemyInterval = 3.5f;
    void Start()
    {
        StartCoroutine(SpawnEnemy(enemyInterval, enemyPrefab));
        StartCoroutine(SpawnEnemy(enemyInterval, enemyPrefab2));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        float randVal = Random.Range(-1f, 1f);
        GameObject newEnemy = Instantiate(enemy, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
 }
