using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    private PlayerMain mainScript;

    void Start()
    {
        mainScript = GetComponent<PlayerMain>();       
    }

    public IEnumerator GetHurt(int damage)
    {
        mainScript.isVulnerable               = false;
        mainScript.movementManager.canMove    = false;
        mainScript.movementManager.VelocityReset();
        GameManager.instance.resetComboCurrent();        
        DecreaseHealth(damage);
        Debug.Log($"Player got hurt and lost {damage}hp. Current HP: {GameManager.instance.playerHpCurrent}");

        mainScript.voiceManager.PlayerHurtVoiceSFX();
        mainScript.playerAnimator.SetBool("isHurt", true);
        mainScript.playerAnimator.SetTrigger("hurtTrigger");
        CinemachineShake.Instance.ShakeCamera(2f, 0.5f);
        if (GameManager.instance.playerHpCurrent <= 0)
        {
            StopCoroutine(GetHurt(damage));
            StartCoroutine(PlayerDeath());
        }
        else
        {
            yield return new WaitForSeconds(0.6f);
            mainScript.playerAnimator.SetBool("isHurt", false);
            mainScript.movementManager.canMove = true;
            mainScript.isVulnerable            = true;
        }
    }
    public IEnumerator PlayerDeath()
    {
        mainScript.movementManager.VelocityReset();
        mainScript.isAlive                     = false;
        mainScript.movementManager.canMove     = false;
        mainScript.playerAnimator.SetBool("isAlive", false);
        mainScript.playerAnimator.SetTrigger("deathTrigger");
        mainScript.voiceManager.PlayerDeathVoiceSFX();
        Debug.Log("Player died.");
        yield return new WaitForSeconds(3.0f);        
        mainScript.SwitchScene(mainScript.sceneRespawn);
        
    }

    public void DecreaseHealth(int health)
    {
        print($"Player has lost {health}hp.");
        GameManager.instance.playerHpCurrent -= health;

        
    } 

    public void IncreaseHealth(int health)
    {
        print($"Player has got {health}hp.");
        GameManager.instance.playerHpCurrent += health;
        
    }

}
