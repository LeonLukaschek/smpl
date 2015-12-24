using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<GameObject> spawnedTiles = new List<GameObject>();
    public List<GameObject> spawnedObstacles = new List<GameObject>();

    public Playercontroller player;

    public enum CurrentState { Right, Middle, Left };

    public GameObject[] tiles;
    public GameObject obstacle;
    public GameObject tileHolder;
    public GameObject obstacleHolder;

    public AudioSource music;

    public int offset;
    public int obstacleOffset;
    public int tileEntered;

    CurrentState currentState;
    //Tile
    bool rightSpawned = false;
    bool leftSpawned = false;
    bool middleSpawned = false;
    //Obstacle
    bool ObsRightSpawned = false;
    bool ObsLeftSpawned = false;
    bool ObsMiddleSpawned = false;

    int spawnedTilesCount;
    int spawnedObstaclesCount;

    void Start()
    {
        obstacleOffset = 20;
        music.Play();
    }

    void FixedUpdate()
    {

        SpawnTiles(tileEntered);
        ResetTilesForSpawn();
        if(obstacleOffset < offset)
        {
            obstacleOffset += 5;
        }
    }

    void SpawnObstacle()
    {
        int randomNumber = Random.Range(0, 3);


        //Reset if every lane has been spawned


        if (!ObsLeftSpawned && randomNumber == 0)
        {
            GameObject obs1 = Instantiate(obstacle.gameObject, new Vector3(-1, 0.6f, obstacleOffset), Quaternion.identity) as GameObject;
            obs1.transform.SetParent(obstacleHolder.gameObject.transform);
            spawnedObstacles.Add(obs1);
            spawnedObstaclesCount++;
            obstacleOffset += 5;
        }
        if (!ObsMiddleSpawned && randomNumber == 1)
        {
            GameObject obs2 = Instantiate(obstacle.gameObject, new Vector3(0, 0.6f, obstacleOffset), Quaternion.identity) as GameObject;
            obs2.transform.SetParent(obstacleHolder.gameObject.transform);
            spawnedObstacles.Add(obs2);
            spawnedObstaclesCount++;
            obstacleOffset += 5;
        }
        if (!ObsRightSpawned && randomNumber == 2)
        {
            GameObject obs3 = Instantiate(obstacle.gameObject, new Vector3(1, 0.6f, obstacleOffset), Quaternion.identity) as GameObject;
            obs3.transform.SetParent(obstacleHolder.gameObject.transform);
            spawnedObstacles.Add(obs3);
            spawnedObstaclesCount++;
            obstacleOffset += 5;
        }
    }


    public void SpawnTiles(int tileCount = 3)
    {
        int randNumber = Random.Range(0, 3);
        if (spawnedTilesCount < tileCount)
        {

            if (!leftSpawned)
            {//Spawn a tile at left position
                leftSpawned = true;
                GameObject tile1 = Instantiate(tiles[randNumber], new Vector3(-1, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile1.name = "Tile_left(" + spawnedTilesCount + ")";
                tile1.transform.SetParent(tileHolder.gameObject.transform);
                spawnedTiles.Add(tile1);
                spawnedTilesCount++;
            }
            if (!middleSpawned)
            {//spawn a tile at middle position
                middleSpawned = true;
                GameObject tile2 = Instantiate(tiles[randNumber], new Vector3(0, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile2.name = "Tile_middle(" + spawnedTilesCount + ")";
                tile2.transform.SetParent(tileHolder.gameObject.transform);
                spawnedTiles.Add(tile2);
                spawnedTilesCount++;
            }
            if (!rightSpawned)
            {//spawn a tile at right position
                rightSpawned = true;
                GameObject tile3 = Instantiate(tiles[randNumber], new Vector3(1, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile3.transform.SetParent(tileHolder.gameObject.transform);
                tile3.name = "Tile_right(" + spawnedTilesCount + ")";
                spawnedTilesCount++;
                spawnedTiles.Add(tile3);

            }

            offset += 20;
            SpawnObstacle();
        }



    }

    void ResetObstaclesForSpawn()
    {
        ObsLeftSpawned = false;
        ObsMiddleSpawned = false;
        ObsRightSpawned = false;

    }

    void ResetTilesForSpawn()
    {
        leftSpawned = false;
        middleSpawned = false;
        rightSpawned = false;
    }

}
