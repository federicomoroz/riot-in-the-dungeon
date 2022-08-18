using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawnerBehaviour : MonoBehaviour
{
                      public  enum         Difficulty   { Easy, Medium, Hard, }

    [SerializeField]  private GameObject[] whatToSpawn;
    [SerializeField]  private GameObject   spawnPoint;
    [SerializeField]  private Difficulty   Level;
                      private  bool        canSpawn     = true;
                      private float        spawnRate    = 3f;
                      private AudioSource  audioSrc;
                      private Transform    itemsPool;
                      private float        rayLength    = 5f;

    void Start()
    {
        itemsPool = GameObject.Find("ItemsPool").transform;
        audioSrc  = GetComponent<AudioSource>();
        LevelSet();
        StartCoroutine(Spawn(spawnRate));
    }

    void Update()
    {
        CheckAbleToSpawn();
    }

    private void CheckAbleToSpawn()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.up, out hit, rayLength))
        { 
            if (hit.transform.CompareTag("PowerUp")) 
            { 
                canSpawn = false;               
            }
        }
        else { canSpawn = true; }
    }

    private void LevelSet()
    {
        switch (Level)
        {
            case Difficulty.Easy:
                spawnRate = 6f;
                break;
            case Difficulty.Medium:
                spawnRate = 9f;
                break;
            case Difficulty.Hard:
                spawnRate = 12f;
                break;
        }

    }

    IEnumerator Spawn(float rate)
    {
        
        yield return new WaitForSeconds(rate);
        int dice = Random.Range(0, 100);
        GameObject what;

        if (dice < 45)       { what = whatToSpawn[0]; }
        else if (dice < 90)  { what = whatToSpawn[1]; }
        else                 { what = whatToSpawn[2]; }


        if (canSpawn)
        {            
            GameObject newItem = Instantiate(what, spawnPoint.transform.position, spawnPoint.transform.rotation);
            newItem.transform.parent = itemsPool;
            audioSrc.Play();
            yield return new WaitForSeconds(rate);
        }
            StartCoroutine(Spawn(rate));
    }
}
