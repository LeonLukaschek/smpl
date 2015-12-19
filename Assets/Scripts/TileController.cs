using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{
    Color[] colors = new Color[9];

    public Renderer rend;
    public GameObject player;

    void Awake()
    {

        colors[0] = Color.cyan;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = new Color(255, 165, 0);
        colors[4] = Color.yellow;
        colors[5] = Color.white;
        colors[6] = Color.blue;
        colors[7] = Color.black;
        colors[8] = Color.gray;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        int randomNum = Random.Range(0, 8);
        rend.material.color = colors[randomNum];
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        StartCoroutine(DestroyOutOfSight());

    }

    IEnumerator DestroyOutOfSight()
    {
        if (Time.deltaTime < 2f)
        {
            yield return new WaitForSeconds(1f);
        }
        if (!rend.isVisible && player.transform.position.z > this.gameObject.transform.position.z)
        {
            Destroy(this.gameObject);
            Debug.Log("destroying: " + this.name);
        }
        yield return new WaitForSeconds(2f);
    }

}
