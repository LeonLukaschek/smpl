using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Playercontroller : MonoBehaviour
{

    public enum currentState { Left, Middle, Right };

    public float speed;
    public float nitroSpeed;

    public currentState currentPosition;

    public Text text;
    public ParticleSystem particle;

    Rigidbody rb;
    private float curSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = currentState.Middle;
        curSpeed = speed;
        text.transform.localScale = new Vector3(2f, 2f, 2f);
        //particle
        particle.enableEmission = false;

    }

    void Update()
    {
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
            text.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            particle.enableEmission = true;
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = curSpeed;
            text.transform.localScale = new Vector3(2f, 2f, 2f);
            particle.enableEmission = false;
        }


        
    }
}
