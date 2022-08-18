using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleBehaviour : MonoBehaviour
{
                 public  string  type;
                 public  int     valueAdd;
[SerializeField] private float   lifeTime        = 5f;
                 private float   lifeTimeCurrent;
[SerializeField] private bool    isAnimated      = false;

[SerializeField] private bool    isRotating      = false;
[SerializeField] private bool    isFloating      = false;
[SerializeField] private bool    isScaling       = false;

[SerializeField] private Vector3 rotationAngle;
[SerializeField] private float   rotationSpeed;

[SerializeField] private float   floatSpeed;
                 private bool    goingUp         = true;
[SerializeField] private float   floatRate;
                 private float   floatTimer;

[SerializeField] private Vector3 startScale;
[SerializeField] private Vector3 endScale;

                 private bool    scalingUp       = true;
[SerializeField] float           scaleSpeed;
[SerializeField] float           scaleRate;
                 private float   scaleTimer;

    private void Start()
    {
        lifeTimeCurrent = lifeTime;
    }

    void Update()
    {
        itemLifeTime();

        if (isAnimated)
        {
            if (isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if (isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, floatSpeed, 0.0f);
                transform.Translate(moveDir * Time.deltaTime);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if (!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if (isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if (scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
    }

    private void itemLifeTime()
    {
        lifeTimeCurrent -= Time.deltaTime;
        if (lifeTimeCurrent <= 0)
        {
            Destroy(gameObject);
        }
    }
}
