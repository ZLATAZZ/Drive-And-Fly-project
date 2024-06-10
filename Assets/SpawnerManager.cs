using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpawnTires());
    }

    IEnumerator SpawnTires()
    {

        while (true)  
        {
          
            float spawnPosZ = Random.Range(-100.0f, 100.0f);

            float spawnPosX = Random.Range(-70.0f, 100.0f);
            float spawnPosY = Random.Range(-15.0f, 30.0f);


            GameObject tire = ObjectToPool.Instance.PooledObject();

            if (tire != null)
            {
               
                tire.transform.position = new Vector3(spawnPosX, spawnPosY, spawnPosZ); 
                tire.gameObject.SetActive(true);
                
            }

            yield return new WaitForSeconds(10.0f);  
        }
    }
}
