using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;


    private void Update()
    {
        GameManager.Instance.LoadChoice();

        score.text = $"The last amount of collected tires: {GameManager.Instance.score}";
    }

    public void ChooseFrontWheel()
    {

        if (GameManager.Instance.front.isOn)
        {
            GameManager.Instance.isFront = true;
            GameManager.Instance.isBack = false;
            GameManager.Instance.back.isOn = false;

        }

    }

    public void ChooseBackWheel()
    {

        if (GameManager.Instance.back.isOn)
        {
            GameManager.Instance.isFront = false;
            GameManager.Instance.isBack = true;
            GameManager.Instance.front.isOn = false;

        }

    }

    public void UpdateScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
