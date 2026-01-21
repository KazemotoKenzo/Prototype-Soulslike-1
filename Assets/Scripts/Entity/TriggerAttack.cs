using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    public bool isAttacking;
    public int damage;

    void Start()
    {
      isAttacking = true;  
    }
}
