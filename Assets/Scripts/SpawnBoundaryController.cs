using UnityEngine;
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
        if (counter == 3)
        {
            var gc = GameObject.Find("GameController");
            gc.GetComponent<GameController>().tileEntered += 3;
        }
    }

    void LateUpdate()
    {
        Vector3 position = target.transform.position + new Vector3(0f, -1.1f, 64.5f);
        this.transform.position = position;
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Tile")
        {
            counter--; 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            counter++; 
        }
    }

}
