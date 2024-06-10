using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMamager : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject helicopter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(car.gameObject.activeSelf)
            {
                helicopter.SetActive(true);
                car.SetActive(false);
                car.transform.position = new Vector3(car.transform.position.x - 5.0f, car.transform.position.y, car.transform.position.z);
            }
            else
            {
                helicopter.SetActive(false);
                car.SetActive(true);

            }
        }
    }
}
