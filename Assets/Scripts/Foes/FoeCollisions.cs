using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCollisions : MonoBehaviour
{
    private FoeMain mainScript;

    void Start()
    {
        mainScript = GetComponent<FoeMain>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            Rigidbody rb            = GetComponent<Rigidbody>();
            string    bulletElement = other.gameObject.GetComponent<BulletMovement>().bulletStats.element;
            int       bulletDamage  = other.gameObject.GetComponent<BulletMovement>().bulletStats.damage;



            if (rb != null)
                {
                    //Knockback
                    Vector3 direction = transform.position - other.transform.position;
                    direction.y       = 0;
                    print("Knockback!");
                    rb.AddForce(direction.normalized * 60f, ForceMode.Impulse);
                    
                }

            
            StartCoroutine(mainScript.damageManager.FoeHurt(bulletElement, bulletDamage));
          
            ;
        }   
    }


}
