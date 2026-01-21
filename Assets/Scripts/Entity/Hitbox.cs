using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private EntityStats entity;

    public LayerMask triggerAttack;

    public void takeDamage(int damage)
    {
        entity.hp -= damage;

        if (entity.hp <= 0) Destroy(transform.root.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<TriggerAttack>(out TriggerAttack triggerAttack) && triggerAttack.isAttacking)
        {
            Debug.Log(other);
            takeDamage(triggerAttack.damage);
        }
    }
}
