using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFX : MonoBehaviour
{
    private BulletMain mainScript;

    public ParticleSystem emissionVFX;
    public ParticleSystem trailVFX;
    public ParticleSystem colissionVFX;


 
    public AudioClip       emissionSFX;   
    public AudioClip       trailSFX;  
    public AudioClip       colissionSFX;

    private void Start()
    {
        mainScript = GetComponent<BulletMain>();
    }
}
