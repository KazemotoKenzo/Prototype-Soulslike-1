using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float hp_max;
    public float hp;

    void Start()
    {
        hp = hp_max;
    }
}
