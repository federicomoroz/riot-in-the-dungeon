using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "New Foe Data", menuName = "Create Foe Data")]
public class FoeData : ScriptableObject
{
    public int hpMax;
    public int attackValue;
    public int scoreGain;
    public int speedMove;
    public int speedRotate;
    public int minDistance;
    public int maxDistance; 
    public string weakToElement;
    public string strongToElement;

}
