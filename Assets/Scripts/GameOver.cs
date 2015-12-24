using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    private float score;

    void Start()
    {
        GameObject scoreS = GameObject.Find("GameController");
        ScoreSystem gameCS = scoreS.GetComponent<ScoreSystem>();
        score = gameCS.score;

        scoreText.text = "Score: " + Mathf.Round(score);
    }

    void Update()
    {

    }
}
