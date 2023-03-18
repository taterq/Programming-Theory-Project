using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] slimePrefabs;
    [SerializeField] private int enemyNum = 1;
    [SerializeField] private float timeToNextWave = 10;
    [SerializeField] private int enemyNumAdd = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSlimeOnTime",5,timeToNextWave);
    }

    void SpawnSlimeOnTime()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            Instantiate(slimePrefabs[Random.Range(0,slimePrefabs.Length)]);
        }
        enemyNum+= enemyNumAdd;
    }
}
