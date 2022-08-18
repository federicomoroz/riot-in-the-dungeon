using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMain : MonoBehaviour
{
    [HideInInspector] public Animator            playerAnimator;
    [HideInInspector] public CharacterController ccPlayer;

    [HideInInspector] public PlayerInputs        inputsManager;
    [HideInInspector] public PlayerMovement      movementManager;
    [HideInInspector] public PlayerCollisions    collisionsManager;
    [HideInInspector] public PlayerHealthManager healthManager;
    [HideInInspector] public PlayerShoot         shootManager;
    [HideInInspector] public PlayerVoiceAudio    voiceManager;
    [HideInInspector] public AudioSource         audioSrcSFX;  
                      public GameObject          playerAmmoMeterCurrent;
                      public GameObject[]        playerAmmoMeter;
  
    

    [HideInInspector] public bool isAlive = true;
    [HideInInspector] public bool isVulnerable = true;   

    public int sceneRespawn;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.resetValuesTotal();
        GameManager.instance.playerHpMax = 100;
        ccPlayer          = GetComponent<CharacterController>();
        movementManager   = GetComponent<PlayerMovement>();
        inputsManager     = GetComponent<PlayerInputs>();
        shootManager      = GetComponent<PlayerShoot>(); 
        collisionsManager = GetComponent<PlayerCollisions>();
        healthManager     = GetComponent<PlayerHealthManager>();
        voiceManager      = GetComponentInChildren<PlayerVoiceAudio>();
        audioSrcSFX       = GetComponent<AudioSource>();
        
        playerAnimator.SetBool("isAlive", true);
        
    }



    public void SwitchScene(int sceneNumber)
    {
        AudioManager.instance.StopStageStong();
        SceneManager.LoadScene(sceneNumber);
    }  

}
