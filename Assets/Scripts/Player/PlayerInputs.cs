using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private PlayerMain mainScript;    

    [HideInInspector] public  float      zAxis;
    [HideInInspector] public  float      yAxis;
    [HideInInspector] public  bool       keyFire;
    [HideInInspector] public  bool       keyRun;
    [HideInInspector] public  bool       keyRunOff;

                      private bool       inputRun1;
                      private bool       inputRun2;
                      private bool       inputRun3;
    
                      private bool       inputFire1;
                      private bool       inputFire2;

    void Start()
    {
        mainScript = GetComponent<PlayerMain>();
    }

    void Update()
    {
        SetKeys();
        CheckKeys();       
    }


    private void CheckKeys()
    {
        if (inputFire1   || inputFire2)                   { keyFire   = true; } else { keyFire   = false; }
        if (inputRun1    || inputRun2    || inputRun3)    { keyRun    = true; } else { keyRun    = false; } 

    }

    private void SetKeys()
    {
        zAxis        = Input.GetAxis("Vertical");
        yAxis        = Input.GetAxis("Horizontal");

        inputFire1   = Input.GetKeyDown(KeyCode.J);
        inputFire2   = Input.GetKeyDown(KeyCode.JoystickButton0);

        inputRun1    = Input.GetKey(KeyCode.LeftShift);
        inputRun2    = Input.GetKey(KeyCode.RightShift);
        inputRun3    = Input.GetKey(KeyCode.Joystick1Button4);

    }
}
