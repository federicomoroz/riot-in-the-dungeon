using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeStats : MonoBehaviour
{
                      private FoeMain mainScript;
                      public  FoeData foeStats;
    [HideInInspector] public  int     hpCurrent;                          
    [HideInInspector] public  bool    isAlive;
                      
    

    void Start()
    {
        mainScript = GetComponent<FoeMain>();
        hpCurrent  = foeStats.hpMax;
        isAlive    = true;
    }


}
