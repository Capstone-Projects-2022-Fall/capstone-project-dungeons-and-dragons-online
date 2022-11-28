using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemy;
    private float xPos;
    private float yPos;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemis());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemis()
    {
        while(enemyCount < 3)
        {
            xPos = (Random.Range(-2, 2)/5f);
            yPos = Random.Range(-2, 2)/5f;
            PhotonNetwork.Instantiate(enemy.name, new Vector2(this.transform.position.x + xPos, this.transform.position.y + yPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
