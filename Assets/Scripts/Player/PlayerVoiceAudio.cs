using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoiceAudio : MonoBehaviour
{
                     public  AudioSource audioSrc;
                     private PlayerMain  mainScript;
    [SerializeField] private AudioClip[] hurtSFX;
    [SerializeField] private AudioClip[] deathSFX;
    [SerializeField] private AudioClip[] startSFX;
    [SerializeField] private AudioClip[] attackSFX;
    [SerializeField] private AudioClip[] elementSFX;
    [SerializeField] private AudioClip[] mockingSFX;
    [SerializeField] private AudioClip[] pickupSFX;


    void Start()
    {
        mainScript = GetComponentInParent<PlayerMain>();
        audioSrc = GetComponent<AudioSource>();
        PlayerStartVoiceSFX();
    }

    private void Update()
    {

    }


    public void PlayerStartVoiceSFX()
    {   audioSrc.PlayOneShot(startSFX[Random.Range(0, startSFX.Length)]);   }

    public void PlayerHurtVoiceSFX()
    {   audioSrc.PlayOneShot(hurtSFX[Random.Range(0, hurtSFX.Length)]);   }

    public void PlayerDeathVoiceSFX()
    {   audioSrc.PlayOneShot(deathSFX[Random.Range(0, deathSFX.Length)]);   }
    public void PlayerAttackVoiceSFX()
    { audioSrc.PlayOneShot(attackSFX[Random.Range(0, attackSFX.Length)], 0.92f); }
    public void PlayerMockingVoiceSFX()
    { audioSrc.PlayOneShot(mockingSFX[Random.Range(0, mockingSFX.Length)]); }
    public void PlayerElementVoiceSFX(int id)
    { audioSrc.PlayOneShot(elementSFX[id]); }
    public void PlayerPickupVoiceSFX()
    { audioSrc.PlayOneShot(pickupSFX[Random.Range(0, pickupSFX.Length)], 1.25f); }


}
