using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BulletCollision : BulletMain
{

    private      BulletMain     mainScript;
    public       ParticleSystem trail;
    public       GameObject     explosion;
    public event Action         onDestroy;
 
    private void Start()
    {
        mainScript = GetComponent<BulletMain>();
        Instantiate(explosion, transform.position, transform.localRotation);
        explosion.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        onDestroy?.Invoke();
        trail.transform.parent = null;
        Instantiate(explosion, transform.position, transform.localRotation);
        explosion.transform.parent = null;
        Debug.Log($"Trigger with {other.gameObject.name}");
        DestroyBullet();      

    }



}
