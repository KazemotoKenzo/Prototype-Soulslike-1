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

    void OnTriggerEnter(Collider other)
    {
      if(isAttacking && other.gameObject.TryGetComponent<Hitbox>(out Hitbox hitbox)) hitbox.takeDamage(damage);
      Debug.Log(other);
    }
}
