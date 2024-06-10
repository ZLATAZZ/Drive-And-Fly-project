using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMamager : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject submarine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(car.gameObject.activeSelf)
            {
                submarine.SetActive(true);
                car.SetActive(false);
            }
            else
            {
                submarine.SetActive(false);
                car.SetActive(true);
            }
        }
    }
}
