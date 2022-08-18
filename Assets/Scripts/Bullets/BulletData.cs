using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bullet Data", menuName = "Create Bullet Data")]

public class BulletData : ScriptableObject
{

    public int    damage;
    public int    speed;
    public string element;
    public float  lifeTime;


}
