using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private float showTime = 2f;
    private int currentHitQ = 0;

    private void LateUpdate()
    {
        currentHitQ = GameManager.instance.currentCombo;
        textMeshPro.SetText(currentHitQ.ToString() + " hits");
        ToggleVisibility();
    }

    private void ToggleVisibility()
    {
        if (currentHitQ == 0)
        {
            gameObject.transform.localScale = new Vector3(0, 0);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1);
        }
    }
}
