using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlipPreventer : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject helicopter;
    private Quaternion rotationCar;
    private Quaternion rotationHelicopter;

    private void Start()
    {
        rotationCar = car.transform.rotation;
        rotationHelicopter = helicopter.transform.rotation;
    }

    public void BackToMenu()
    {
        GameManager.Instance.SaveChoice();
        
        SceneManager.LoadScene(0);
        
    }

    public void Reload()
    {
        car.transform.rotation = rotationCar;
        helicopter.transform.rotation = rotationHelicopter;
        Debug.Log("Why we don't reload");
    }
}
