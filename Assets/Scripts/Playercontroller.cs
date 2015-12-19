using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour
{

    public enum currentState { Left, Middle, Right };

    public float speed;

    Rigidbody rb;
    public currentState currentPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = currentState.Middle;
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
    }
}
