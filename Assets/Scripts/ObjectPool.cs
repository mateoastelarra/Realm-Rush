using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawningTime = 1f;

   void Start()
    {
        StartCoroutine(SpawnEnemiesContinuosly());
    }

   void OnDisable()
   {
        StopAllCoroutines();
   }

   IEnumerator SpawnEnemiesContinuosly()
   {
        while (true)
        {
            Instantiate(enemy);
            yield return new WaitForSeconds(spawningTime);
        }    
   }
}
