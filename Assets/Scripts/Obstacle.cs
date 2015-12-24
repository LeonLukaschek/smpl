using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{

    public Renderer rend;


    private GameObject player;

    Color[] colors = new Color[9];

    void Awake()
    {
        colors[0] = Color.red;
    }

    void Start()
    {
        rend.material.color = colors[0];
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        StartCoroutine(DestroyOutOfSight());
    }

    IEnumerator DestroyOutOfSight()
    {
        if (!rend.isVisible && player.transform.position.z > this.gameObject.transform.position.z)
        {
            GameObject gameC = GameObject.Find("GameController");
            GameController gameCS = gameC.GetComponent<GameController>();
            gameCS.spawnedObstaclesCount--;
            Destroy(this.gameObject);
        }
        yield return new WaitForSeconds(2f);
    }
}
