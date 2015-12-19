using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<GameObject> spawnedTiles = new List<GameObject>();

    public Playercontroller player;

    public GameObject[] tiles;
    public GameObject tileHolder;


    public int offset;
    public int tileEntered;

    bool rightSpawned = false;
    bool leftSpawned = false;
    bool middleSpawned = false;

    int spawnedTilesCount;

    void Start()
    {
    }

    void FixedUpdate()
    {
        SpawnTiles(tileEntered);

        ResetForSpawn();
    }

    public void SpawnTiles(int tileCount = 3)
    {
        int randNumber = Random.Range(0, 3);
        if(spawnedTilesCount < tileCount)
        {

            if (!leftSpawned)
            {
                leftSpawned = true;
                GameObject tile1 = Instantiate(tiles[randNumber], new Vector3(-1, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile1.name = "Tile_left(" + spawnedTilesCount + ")";
                tile1.transform.SetParent(tileHolder.gameObject.transform);
                spawnedTiles.Add(tile1);
                spawnedTilesCount++;
            }
            if (!middleSpawned)
            {
                middleSpawned = true;
                GameObject tile2 = Instantiate(tiles[randNumber], new Vector3(0, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile2.name = "Tile_middle(" + spawnedTilesCount + ")";
                tile2.transform.SetParent(tileHolder.gameObject.transform);
                spawnedTiles.Add(tile2);
                spawnedTilesCount++;
            }
            if (!rightSpawned)
            {
                rightSpawned = true;
                GameObject tile3 = Instantiate(tiles[randNumber], new Vector3(1, 0, 0 + offset), Quaternion.Euler(0, 90, 0)) as GameObject;
                tile3.transform.SetParent(tileHolder.gameObject.transform);
                tile3.name = "Tile_right(" + spawnedTilesCount + ")";
                spawnedTilesCount++;
                spawnedTiles.Add(tile3);

            }

            offset += 20;
            Debug.Log("GameController.spawnTiles called");
            Debug.Log(spawnedTilesCount);
        }



    }

    void ResetForSpawn()
    {
        leftSpawned = false;
        middleSpawned = false;
        rightSpawned = false;
    }
}
