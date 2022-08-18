using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeMovement : MonoBehaviour
{
                      public  enum       FoeType       { Fixed, Chaser, ChaserShooter, }
                     
                      private FoeMain    mainScript;
                      public  FoeType    behaviour;
    [HideInInspector] public  GameObject target;


    void Start()
    {
        mainScript = GetComponent<FoeMain>();
        target     = GameObject.Find("Player");
        mainScript.foeAnimator.SetBool("isWalking", false);
    }

    void Update()
    {
        if (mainScript.statsManager.isAlive == true)  { SetBehaviour(behaviour); } 
    }

    private void SetBehaviour(FoeType style)
    {
        switch (style)
        {
            case FoeType.Fixed:
                Look(target, mainScript.statsManager.foeStats.speedRotate);
                break;
            case FoeType.Chaser:
                Look(target, mainScript.statsManager.foeStats.speedRotate);
                MoveTowards(target, mainScript.statsManager.foeStats.speedMove, mainScript.statsManager.foeStats.maxDistance, mainScript.statsManager.foeStats.minDistance);
                break;
            case FoeType.ChaserShooter:
                Look(target, mainScript.statsManager.foeStats.speedRotate);
                MoveTowards(target, mainScript.statsManager.foeStats.speedMove, mainScript.statsManager.foeStats.maxDistance, mainScript.statsManager.foeStats.minDistance);
                mainScript.shootManager.RaycastCheck();
                break;
        }
    }

    public void Look(GameObject who, float speed)
    {
        Quaternion newRotation = Quaternion.LookRotation(who.transform.position - transform.position);
        transform.rotation     = Quaternion.Lerp(transform.rotation, newRotation, speed * Time.deltaTime);
    }

    public void MoveTowards(GameObject who, float speed, float start, float stop)
    {
        Vector3 dir = (who.transform.position - transform.position);
        if (dir.magnitude > stop && dir.magnitude < start)
        {
            transform.position += speed * dir.normalized * Time.deltaTime;
            mainScript.foeAnimator.SetBool("isWalking", true);

        }
        else
        {
            mainScript.foeAnimator.SetBool("isWalking", false);

            if (behaviour == FoeType.ChaserShooter)
            { 
                if (dir.magnitude <= stop && mainScript.shootManager.isLoaded && mainScript.shootManager.isTarget) 
                { 
                    StartCoroutine(mainScript.shootManager.DragonShoot()); 
                } 
            }
        }
    }


}
