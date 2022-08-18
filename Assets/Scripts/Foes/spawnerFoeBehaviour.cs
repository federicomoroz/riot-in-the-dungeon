using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnerFoeBehaviour : MonoBehaviour
{
                     public  enum         Difficulty    {  Easy, Medium, Hard,  }

    [SerializeField] private GameObject[] foesPrefabs;    
    [SerializeField] private Difficulty   Level;        
                     private float        spawnRate    = 3f;
                     private AudioSource  audioSrc;
                     private Transform    foesPool;
                      
    
    void Start()
    {        
        foesPool = GameObject.Find("FoesPool").transform;
        audioSrc = GetComponent<AudioSource>();
        LevelSet();
        StartCoroutine(Spawn(spawnRate));

    }
    private void LevelSet()
    {
        switch (Level)
        {
            case Difficulty.Easy:
                spawnRate = 8f;
                break;
            case Difficulty.Medium:
                spawnRate = 6f;
                break;
            case Difficulty.Hard:
                spawnRate = 5f;
                break;
        }

    }


    IEnumerator Spawn (float rate)
    {
        float spawnStartDelay = 0.3f;                                                
        yield return new WaitForSeconds(spawnStartDelay);       
        GameObject newFoe;
        int dice              = Random.Range(0, 100);

        if      (dice < 45)   {  newFoe = foesPrefabs[0];  }    // 45% Ghost
        else if (dice < 90)   {  newFoe = foesPrefabs[1];  }    // 45% Troll
        else                  {  newFoe = foesPrefabs[2];  }    // 10% Dragon            

        newFoe                  = Instantiate(newFoe, transform.position, newFoe.transform.rotation);   
        newFoe.transform.parent = foesPool;
        audioSrc.Play();
        yield return new WaitForSeconds(rate);
        StartCoroutine(Spawn(rate));

    }
}
