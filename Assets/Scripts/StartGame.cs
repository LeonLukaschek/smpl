using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

    public void LoadLevel()
    {
        Debug.Log("Load level game");
        Application.LoadLevel("game");

    }
}
