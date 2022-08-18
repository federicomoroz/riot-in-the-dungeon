using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Collectible
{
    public int hpGain;
    public override void Apply(GameObject target)
    {
        GameManager.instance.playerHpCurrent += hpGain;
    }
}
