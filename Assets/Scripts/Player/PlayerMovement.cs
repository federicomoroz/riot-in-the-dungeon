using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
                      private    PlayerMain mainScript;

    [HideInInspector] public     bool       canMove             = true;
    [SerializeField]  private    float      playerWalkSpeed     = 10f;
    [SerializeField]  private    float      playerRotateSpeed   = 100f;
    [SerializeField]  private    float      playerRunSpeed      = 15f;   
                      private    float      playerCurrentSpeed;
                      private    bool       hasGravity          = true;
                      private    float      forceGravity        = 9.8f;
                      private    float      velocityZ           = 0.0f;
                      private    float      velocityX           = 0.0f;

    void Start()
    {
        mainScript         = GetComponent<PlayerMain>();
        playerCurrentSpeed = playerWalkSpeed;
    }

     void Update()
    {
        if (mainScript.isAlive) { Inputs(); }
        if (hasGravity)         { Gravity(); }
   
    }

    private void Gravity()
    { mainScript.ccPlayer.Move(Vector3.down * forceGravity * Time.deltaTime); }

    private void Inputs()
    { if (canMove) { WalkAxisZ(); RotateAxisY(); RunToggle(); } }

    void WalkAxisZ()
    {
        Vector3 dir = new Vector3(0, 0, mainScript.inputsManager.zAxis);
        mainScript.ccPlayer.Move(transform.TransformDirection(dir) * playerCurrentSpeed * Time.deltaTime);
        velocityZ = mainScript.inputsManager.zAxis;
        mainScript.playerAnimator.SetFloat("VelocityZ", velocityZ);
    }

    void RotateAxisY()
    {
        transform.Rotate(Vector3.up * mainScript.inputsManager.yAxis * playerRotateSpeed * Time.deltaTime);
        velocityX = mainScript.inputsManager.yAxis;
        mainScript.playerAnimator.SetFloat("VelocityX", velocityX);
    }
    private void RunToggle()
    {
        if (mainScript.inputsManager.keyRun)  { ToggleRunOn(); } else { ToggleRunOff(); } 
    }

    void ToggleRunOn() { playerCurrentSpeed = playerRunSpeed; }

    void ToggleRunOff() { playerCurrentSpeed = playerWalkSpeed; }

    public void VelocityReset()
    {  velocityX = 0.0f; velocityZ = 0.0f;   }


}
