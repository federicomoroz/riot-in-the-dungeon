using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class FoeMain : Foe
{
    
                      public string        foeName;                                          
                      public AudioClip     sfxDeath;
                      public GameObject[]  itemDrop;
      [Range(0, 100)] public float         itemDropChance;
    [HideInInspector] public FoeStats      statsManager;
    [HideInInspector] public FoeCollisions collisionsManager;
    [HideInInspector] public FoeDamage     damageManager;
    [HideInInspector] public FoeMovement   movementManager;
    [HideInInspector] public FoeShooter    shootManager;
    [HideInInspector] public Animator      foeAnimator;    
    [HideInInspector] public AudioSource   audioSrc;
      
    void Start()
    {
        statsManager         = GetComponent<FoeStats>();
        collisionsManager    = GetComponent<FoeCollisions>();
        damageManager        = GetComponent<FoeDamage>();
        movementManager      = GetComponent<FoeMovement>();
        shootManager         = GetComponent<FoeShooter>();
        audioSrc             = GetComponent<AudioSource>();
   
     
    }


}
