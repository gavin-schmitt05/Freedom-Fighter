using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject strongEnemyPrefab;

    private float strongEnemyInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(spawnEnemy(strongEnemyInterval, strongEnemyPrefab));
        
        
        



    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f , 1f), Random.Range(-1f , 1f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));

    }
}
