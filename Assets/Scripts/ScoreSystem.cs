using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Playercontroller player;
    public Text scoreText;

    public float score = 0;
    public float pointsPerSecond;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Mathf.Round(score).ToString();

        score += (pointsPerSecond * player.speed) * Time.deltaTime;
    }


}
