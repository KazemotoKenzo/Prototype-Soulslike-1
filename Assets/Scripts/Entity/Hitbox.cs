using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private EntityStats entity;

    public void takeDamage(int damage)
    {
        entity.hp -= damage;

        if (entity.hp <= 0) Destroy(gameObject.GetComponentInParent<GameObject>());
    }
}
