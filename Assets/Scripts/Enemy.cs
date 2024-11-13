using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    [SerializeField]
    RectTransform currentHealthTransform;
    [SerializeField]
    RectTransform maxHealthTransform;

    private void OnEnable()
    {
        Events.playerAttack += takeDamage;
    }

    private void OnDisable()
    {
        Events.playerAttack -= takeDamage;
    }

    private void takeDamage(int damage)
    {
        health -= damage;
        currentHealthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxHealthTransform.rect.width * (float) health / maxHealth);
        if(health > 0)
        {
            Events.enemyAttack?.Invoke(10);
        }
    }
}
