using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefab;
    private float rx;
    private float ry;
    private float offset = 4;

    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(0.5f, 3f); // creates a random interval time between 2 and 5 seconds.
        StartCoroutine(spawnEnemy(interval)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private GameObject RandomEnemy()
    {
        return enemyPrefab[Random.Range(0, enemyPrefab.Length)];
    }
    

    private IEnumerator spawnEnemy (float _interval)
    {
        rx = Random.Range(-5f, 5f);
        rx += Mathf.Sign(rx)*offset;

        ry = Random.Range(-5f, 5f);
        ry += Mathf.Sign(ry)*offset;

        Instantiate(RandomEnemy(), new Vector3(rx, ry, 0), Quaternion.identity);

        yield return new WaitForSeconds(_interval); // wait before next spawn

        _interval = Random.Range(0.5f, 3f); // creates random interval between 2 and 5 secs
        StartCoroutine(spawnEnemy(_interval)); // pass the same values, will try a Random.Range later on
    }
}
