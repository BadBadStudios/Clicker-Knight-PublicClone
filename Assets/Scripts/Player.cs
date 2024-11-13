using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    [SerializeField]
    RectTransform currentHealthTransform;
    [SerializeField]
    RectTransform maxHealthTransform;

    private void OnEnable()
    {
        Events.enemyAttack += takeDamage;
    }

    private void OnDisable()
    {
        Events.enemyAttack -= takeDamage;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Events.playerAttack?.Invoke(20);
        }
    }

    private void takeDamage(int damage)
    {
        health -= damage;
        currentHealthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxHealthTransform.rect.width * (float)health / maxHealth);
    }
}
