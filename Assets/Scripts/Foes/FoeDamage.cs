using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeDamage : Foe
{
                     private FoeMain    mainScript;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private string     weakType;
    [SerializeField] private string     strongType;

    void Start()
    {
        mainScript = GetComponent<FoeMain>();
    }

    public IEnumerator FoeHurt(string type, int damage)
    {             
       if (type == mainScript.statsManager.foeStats.weakToElement) 
       { 
            damage *= 2;
            print($"{type} ball was super efective. Damage x2");
       }
       else if (type == mainScript.statsManager.foeStats.strongToElement) 
       {
            damage /= 2; 
            print($"{type} ball was not very efective. Damage x0.5");
       }
       else
        {
            damage *= 1;
        }
        mainScript.statsManager.hpCurrent -= damage;
        print($"{mainScript.foeName} got hit by a {type} ball and lost {damage}hp.");
        if (mainScript.statsManager.hpCurrent <= 0)
        {
            StartCoroutine(FoeDeath());
        }
        yield return new WaitForSeconds(1f);

    }

    public IEnumerator FoeDeath()
    {
        mainScript.statsManager.isAlive                      = false;
        mainScript.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 10f, 0f);
        mainScript.audioSrc.PlayOneShot(mainScript.sfxDeath);
        mainScript.foeAnimator.SetBool("didDie", true);
        yield return new WaitForSeconds(0.8f);
        GameManager.instance.updateScore(mainScript.foeName, mainScript.statsManager.foeStats.scoreGain);
        ItemDropDice(mainScript.itemDropChance, mainScript.itemDrop[0]);
        Instantiate(explosionVFX, transform.position, explosionVFX.transform.localRotation);
        explosionVFX.transform.parent = null;
        DestroyFoe();
    }

    public void ItemDropDice(float chance, GameObject item)
    {
        float dice = Random.Range(0, 100);
        if (dice < chance)
        {
            ItemDrop(item);
        }
    }

    public void ItemDrop(GameObject item)
    {
        GameObject newItem       = Instantiate(item, gameObject.transform.position, gameObject.transform.rotation);
        Transform itemsPool      = GameObject.Find("ItemsPool").transform;
        newItem.transform.parent = itemsPool;

    }

}
