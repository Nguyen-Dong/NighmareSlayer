using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;

    private void Start()
    {

    }

    public void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
