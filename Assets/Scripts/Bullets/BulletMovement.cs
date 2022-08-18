using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : BulletMain
{
                     private   BulletMain     mainScript;
                     public    BulletData     bulletStats;
                     private   float          bulletLifeTimeCurrent;
          

    void Start()
    {
        TimerReset();
    }


    void Update()
    {
        // MOVEMENT
        Movement(Vector3.forward);

        // TIMER
        BulletTimer();        

        // BULLET DESTROY
        if (bulletLifeTimeCurrent <= 0) BulletDestroy();
    }
    void Movement(Vector3 dir)
    { transform.Translate(dir * bulletStats.speed * Time.deltaTime); }

    void TimerReset()
    { bulletLifeTimeCurrent = bulletStats.lifeTime; }

    void BulletTimer()
    { bulletLifeTimeCurrent -= Time.deltaTime; }

    void BulletDestroy()
    { Destroy(gameObject); }
}
