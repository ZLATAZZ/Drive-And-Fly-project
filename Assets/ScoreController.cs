using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCar;
    [SerializeField] protected TextMeshProUGUI scoreHelicopter;

    private void Update()
    {
        scoreCar.text = $"Score: {CollisionManager.score.ToString()}";
        scoreHelicopter.text = $"Score: {CollisionManager.score.ToString()}";
    }
}
