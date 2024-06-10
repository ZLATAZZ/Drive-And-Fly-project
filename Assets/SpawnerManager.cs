using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(SpawnTires());
    }

    IEnumerator SpawnTires()
    {
        float spawnPos = Random.Range(0.0f, 15.0f);
        GameObject tire = ObjectToPool.Instance.PooledObject();

        if(tire != null)
        {
            tire.transform.position = new Vector3(spawnPos, spawnPos, spawnPos);
            tire.gameObject.SetActive(true);

            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

    }
}
