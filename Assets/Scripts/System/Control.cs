using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   {  GameQuit();  }
    }

    public void GameQuit()
    {
        print("Escape pressed. Quitting game");
        Application.Quit();
    }
}
