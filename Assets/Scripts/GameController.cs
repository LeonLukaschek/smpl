using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<GameObject> spawnedTiles = new List<GameObject>();

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

    public int spawnedObstaclesCount = 0;

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

    void Start()
    {
        obstacleOffset = 15;
        music.Play();
    }

    void FixedUpdate()
    {
        SpawnTiles(tileEntered);
        ResetTilesForSpawn();
        if (obstacleOffset < offset)
        {
            obstacleOffset += 5;
        }
    }

    void SpawnObstacle()
    {
        if (spawnedObstaclesCount < 10)
        {
            int randomNumber = Random.Range(0, 3);

            if (!ObsLeftSpawned && randomNumber == 0)
            {
                GameObject obs1 = Instantiate(obstacle.gameObject, new Vector3(-1, .5f, obstacleOffset), Quaternion.identity) as GameObject;
                obs1.transform.SetParent(obstacleHolder.gameObject.transform);
                spawnedObstaclesCount++;
                obstacleOffset += 10;
                return;
            }
            if (!ObsMiddleSpawned && randomNumber == 1)
            {
                GameObject obs2 = Instantiate(obstacle.gameObject, new Vector3(0, .5f, obstacleOffset), Quaternion.identity) as GameObject;
                obs2.transform.SetParent(obstacleHolder.gameObject.transform);
                spawnedObstaclesCount++;
                obstacleOffset += 5;
                return;
            }
            if (!ObsRightSpawned && randomNumber == 2)
            {
                GameObject obs3 = Instantiate(obstacle.gameObject, new Vector3(1, .5f, obstacleOffset), Quaternion.identity) as GameObject;
                obs3.transform.SetParent(obstacleHolder.gameObject.transform);
                spawnedObstaclesCount++;
                obstacleOffset += 10;
                return;
            }
        }
    }


    public void SpawnTiles(int tileCount = 3)
    {
        int randNumber = Random.Range(0, 3);
        if (spawnedTilesCount < tileCount)
        {

            if (!leftSpawned)
            {
                //Spawn a tile at left position
                leftSpawned = true;
                GameObject tile1 = Instantiate(tiles[randNumber], new Vector3(-1, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile1.name = "Tile_left(" + spawnedTilesCount + ")";
                tile1.transform.SetParent(tileHolder.gameObject.transform);
                spawnedTiles.Add(tile1);
                spawnedTilesCount++;
                if (spawnedTiles.Count > 25)
                {
                    SpawnObstacle();
                }
            }
            if (!middleSpawned)
            {
                //spawn a tile at middle position
                middleSpawned = true;
                GameObject tile2 = Instantiate(tiles[randNumber], new Vector3(0, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile2.name = "Tile_middle(" + spawnedTilesCount + ")";
                tile2.transform.SetParent(tileHolder.gameObject.transform);
                spawnedTiles.Add(tile2);
                spawnedTilesCount++;
                SpawnObstacle();
            }
            if (!rightSpawned)
            {
                //spawn a tile at right position
                rightSpawned = true;
                GameObject tile3 = Instantiate(tiles[randNumber], new Vector3(1, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile3.transform.SetParent(tileHolder.gameObject.transform);
                tile3.name = "Tile_right(" + spawnedTilesCount + ")";
                spawnedTilesCount++;
                spawnedTiles.Add(tile3);
                if (spawnedTiles.Count > 50)
                {
                    SpawnObstacle();
                }
            }

            SpawnObstacle();

            offset += 20;
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
