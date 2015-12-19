﻿using UnityEngine;
using System.Collections;

public class SpawnBoundaryController : MonoBehaviour
{
    public Playercontroller player;
    public GameObject target;

    public int counter;

    void Start()
    {
        counter = 0;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        Vector3 position = target.transform.position + new Vector3(0f, -1.1f, 64.5f);
        this.transform.position = position;
    }

    void OnTriggerExit(Collider other)
    {
        if (counter == 3)
        {
            Debug.Log("Spawing new tiles via spawnboundarycontroller");
            var gc = GameObject.Find("GameController");
            gc.GetComponent<GameController>().tileEntered += 3;
        }
        counter --;
    }

    void OnTriggerEnter(Collider other)
    {
        counter ++;
    }

}