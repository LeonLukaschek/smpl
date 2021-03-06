﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Playercontroller : MonoBehaviour
{

    public enum currentState { Left, Middle, Right };
    public GameObject gameOverScreen;

    public float speed;
    public float nitroSpeed;

    public int maxHealth = 5;
    public int playerHealth;

    public currentState currentPosition;

    public Text text;
    public Text healthText;
    public ParticleSystem particle;

    Rigidbody rb;
    private float curSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = currentState.Middle;
        playerHealth = maxHealth;
        gameOverScreen.SetActive(false);
        curSpeed = speed;
        //particle
        particle.enableEmission = false;

    }

    void Update()
    {

        if (playerHealth > 0)
        {
            healthText.text = "Health: " + playerHealth;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //Move left
            if (Input.GetKeyDown(KeyCode.A) && currentPosition != currentState.Left)
            {
                if (currentPosition == currentState.Right)
                {
                    currentPosition = currentState.Middle;
                    transform.Translate(Vector3.left);
                    return;
                }

                if (currentPosition == currentState.Middle)
                {
                    currentPosition = currentState.Left;
                    transform.Translate(Vector3.left);
                    return;
                }
            }

            //Move right
            if (Input.GetKeyDown(KeyCode.D) && currentPosition != currentState.Right)
            {
                if (currentPosition == currentState.Left)
                {
                    transform.position += Vector3.right;
                    currentPosition = currentState.Middle;
                    return;
                }

                if (currentPosition == currentState.Middle)
                {
                    transform.position += Vector3.right;
                    currentPosition = currentState.Right;
                    return;
                }
            }

            //Nitro
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speed = nitroSpeed;
                particle.enableEmission = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                speed = curSpeed;
                particle.enableEmission = false;
            }
        }
        else
        {
            healthText.text = "";
            speed = 0;
            gameOverScreen.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            playerHealth--;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2);
        }
    }

}
