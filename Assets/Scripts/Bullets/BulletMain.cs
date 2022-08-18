using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : Bullet
{
    [HideInInspector] public    BulletMovement  movementManager;
    [HideInInspector] public    BulletCollision collisionsManager;    
                      private   AudioSource     audioSrc;
  
    void Start()
    {
        movementManager   = GetComponent<BulletMovement>();
        collisionsManager = GetComponent<BulletCollision>();
        audioSrc          = GetComponent<AudioSource>();
        
    }

}
