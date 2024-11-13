using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int attack;
    public int defense;
    public SpriteRenderer spriteRenderer;
    public Monster monster;
    public TextMeshProUGUI enemyNameText;
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

    public void Initialize(Monster monster)
    {
        health = monster.health;
        maxHealth = monster.health;
        attack = monster.attack;
        defense = monster.defense;
        spriteRenderer.sprite = monster.sprite;
        this.monster = monster;
        enemyNameText.text = monster.name;
    }

    private void takeDamage(int damage)
    {
        if (health <= 0)
            return;
        damage -= defense;
        damage = Mathf.Max(0, damage);
        health -= damage;
        currentHealthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxHealthTransform.rect.width * (float) health / maxHealth);
        if(health <= 0)
        {
            Events.enemyDied?.Invoke(monster);
            return;
        }
        Events.enemyAttack?.Invoke(attack);
    }
}
