using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeShooter : MonoBehaviour
{
                      private FoeMain mainScript;

                      public  GameObject shootPoint;                     
    [SerializeField]  private GameObject bullet;
    [SerializeField]  private float      shootReloadTime = 2f;              
    [SerializeField]  private float      raycastRange    = 100f;
    [HideInInspector] public  bool       isLoaded        = true;    
    [HideInInspector] public  bool       isTarget        = false;   
                      private Transform  bulletsPool;                    

  
    void Start()
    {
        mainScript = GetComponent<FoeMain>();
        bulletsPool = GameObject.Find("BulletsPool").transform;
    }

    public void RaycastCheck()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, raycastRange))
        {
            if (hit.transform.CompareTag("Player"))
            {
                isTarget = true;
                print($"Player is in sight of Dragon");
            }
            else
            {
                isTarget = false;
            }
        }
    }

    public IEnumerator DragonShoot()
    {
        isLoaded                   = false;
        GameObject newBullet       = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        //newBullet.GetComponent<BulletMovement>().damageValue = mainScript.statsManager.attackValue;
        newBullet.transform.parent = bulletsPool;
        yield return new WaitForSeconds(shootReloadTime);
        isLoaded                   = true;
    }


}
