using System;
using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int objectPoolSize = 5;
    [SerializeField] [Range(0.1f, 30)] float spawningTime = 1f;

    private GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

   void OnDisable()
   {
        StopAllCoroutines();
   }

   private void PopulatePool()
   {
        pool = new GameObject[objectPoolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
   }

    void ActiveObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            ActiveObjectInPool();
            yield return new WaitForSeconds(spawningTime);
        }    
    }
}
