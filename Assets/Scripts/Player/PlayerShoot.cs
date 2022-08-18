using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

                      private      PlayerMain   mainScript;   
    [SerializeField]  private      float        shootRate        = 0.25f;
    [SerializeField]  private      GameObject   shootPoint;
                      private      AudioClip    currentShootSFX;
    [SerializeField]  private      AudioClip[]  shootSFX;
                      private      GameObject   currentBall;
    [SerializeField]  private      GameObject[] energyBalls;
                      private      int          currentBallID    = 9;   
                      private      Transform    bulletsPool;
    [HideInInspector] public       bool         canShoot         = true;
                      public       int          ammoCurrent;
                      public       int          ammoMax          = 99;
    [SerializeField]  private      int          ammoStart        = 30;
                      private      bool         isFullAmmo       = false;

    void Start()
    {
       mainScript  = GetComponent<PlayerMain>();          
       bulletsPool = GameObject.Find("BulletsPool").transform;
       StartEnergyBall(0);      
       mainScript.playerAmmoMeterCurrent.GetComponent<AmmoMeter>().SetMaxAmmo(ammoMax);
    }
      
    void Update()
    {
        Inputs();
        AmmoCap(ammoCurrent, ammoMax);
    }

    private void FixedUpdate()
    {
        UpdateAmmoMeter();
    }

    private void UpdateAmmoMeter()
    {
        mainScript.playerAmmoMeterCurrent.GetComponent<AmmoMeter>().SetAmmo(ammoCurrent);
    }

    void Inputs()
    {
   
        if (mainScript.inputsManager.keyFire && canShoot && mainScript.isAlive)   { ShootController(1); }
  
        if (Input.GetKeyDown(KeyCode.Alpha1))   { SwitchEnergyBall(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2))   { SwitchEnergyBall(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3))   { SwitchEnergyBall(2); }

    }

    void ShootController(int q)
    {
        StartCoroutine(Shoot(ammoCurrent, shootRate));
    }

    IEnumerator Shoot(int ammo, float rate)
    {
        if (ammo > 0)
        {
            canShoot                   = false;
            mainScript.playerAnimator.SetTrigger("attackTrigger");
            GameObject newBullet       = Instantiate(currentBall, shootPoint.transform.position, shootPoint.transform.rotation);
            mainScript.voiceManager.PlayerAttackVoiceSFX();
            CinemachineShake.Instance.ShakeCamera(2f, 0.35f);
            ammoCurrent--;
            print($"Ammo: {ammoCurrent}");
            newBullet.transform.parent = bulletsPool;
            mainScript.audioSrcSFX.PlayOneShot(currentShootSFX);                     
            yield return new WaitForSeconds(rate);
            canShoot                   = true;
            StopAllCoroutines();  
        }
        else
        {
            print("No ammo");
        }


    }
    public void StartEnergyBall(int id)
    {        
        if (id != currentBallID)  { ammoCurrent = 0; }
        currentBall     = energyBalls[id];
        currentBallID   = id;
        currentShootSFX = shootSFX[id];
        ammoCurrent    += ammoStart;        
        SwitchAmmoMeter(id);

    }

    public void SwitchEnergyBall(int id)
    {
        if (id != currentBallID) { ammoCurrent = 0; }
        currentBall = energyBalls[id];
        currentBallID = id;
        currentShootSFX = shootSFX[id];
        ammoCurrent += ammoStart;
        mainScript.voiceManager.PlayerElementVoiceSFX(id);
        SwitchAmmoMeter(id);

    }

    public void SwitchAmmoMeter(int id)
    {
        for (int i = 0; i < mainScript.playerAmmoMeter.Length; i++)
        {
            mainScript.playerAmmoMeter[i].SetActive(false);
        }
        mainScript.playerAmmoMeter[id].SetActive(true);
        mainScript.playerAmmoMeterCurrent = mainScript.playerAmmoMeter[id];
    }

    private void AmmoCap(int current, int max)
    {
        if (current    == max)
        {
            isFullAmmo  = true;
        }
        else
        {
            isFullAmmo  = false;
            if (current > max)
            {
                current = max;
            }
            else if (current < 0)
            {
                current = 0;
            }

        }
        ammoCurrent     = current;
    }

}
