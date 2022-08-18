using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    [SerializeField] List<GameObject> cams = new List<GameObject>();
    [SerializeField] GameObject currentCamera;
    
 
    // Start is called before the first frame update
    void Start()
    {
        SelectorCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();        
    }

    private void Inputs()
    {        
        if (Input.GetKeyDown(KeyCode.F1))   {  SelectorCamera(0);  }
        if (Input.GetKeyDown(KeyCode.F2))   {  SelectorCamera(1);  }
    }

    void SelectorCamera(int camIndex)
    {
        ShutOffCameras();
        EnableCamera(camIndex, true);
    }

    private void ShutOffCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            EnableCamera(i, false);
        }
    }

    void EnableCamera(int index, bool status)
        
    {
        cameras[index].SetActive(status);
        currentCamera = cameras[index];
    }
}
