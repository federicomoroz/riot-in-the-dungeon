using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerMain mainScript;
   
    void Start()
    {
        mainScript = GetComponent<PlayerMain>();
    }
   

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (mainScript.isAlive)
        {
            if (other.gameObject.CompareTag("Enemy") && other.gameObject.GetComponent<FoeMain>().statsManager.isAlive)
            {
                Debug.Log($"Collision with {other.gameObject.name}");
                if (mainScript.isVulnerable)
                {
                    int damage = other.gameObject.GetComponent<FoeMain>().statsManager.foeStats.attackValue;
                    StartCoroutine(mainScript.healthManager.GetHurt(damage));
                }
            }

        }
    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (mainScript.isAlive)
        {

            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Debug.Log($"Collision with {other.gameObject.name}");
                int damage = other.gameObject.GetComponent<BulletMovement>().bulletStats.damage;
                StartCoroutine(mainScript.healthManager.GetHurt(damage));
            }


            if (other.gameObject.CompareTag("PowerUp"))
            {
               
                switch (other.gameObject.GetComponent<collectibleBehaviour>().type)
                {
                    case "bullet_Lava":
                        print("Lava ball!");
                        mainScript.shootManager.SwitchEnergyBall(0);
                        break;
                    case "bullet_Ice":
                        print("Ice ball!");
                        mainScript.shootManager.SwitchEnergyBall(1);
                        break;
                    case "bullet_Cosmic":
                        print("Cosmic ball!");
                        mainScript.shootManager.SwitchEnergyBall(2);
                        break;
                    case "potion_Hp":
                        print($"Picked a Health Potion.");
                        mainScript.voiceManager.PlayerPickupVoiceSFX();
                        mainScript.healthManager.IncreaseHealth(other.gameObject.GetComponent<collectibleBehaviour>().valueAdd);
                        break;
                }
                Destroy(other.gameObject);

            }

        }

    }

}
