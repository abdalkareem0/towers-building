using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private float Score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateScore(float score)
    {
        Score += score;
        scoreText.text = "Score: " + (int)Score;
    }
}
