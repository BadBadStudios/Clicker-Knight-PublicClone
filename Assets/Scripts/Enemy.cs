using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Monster monster;
    int health;
    int maxHealth;
    int attack;
    int defense;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    TextMeshProUGUI enemyNameText;
    [SerializeField]
    RectTransform currentHealthTransform;
    [SerializeField]
    RectTransform maxHealthTransform;
    [SerializeField]
    Animator animator;
    [SerializeField]
    AnimatorController defaultAnimatorController;

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
        animator.ResetTrigger("Dead");
        animator.ResetTrigger("Damaged");
        health = monster.health;
        maxHealth = monster.health;
        attack = monster.attack;
        defense = monster.defense;
        this.monster = monster;
        enemyNameText.text = monster.name;
        spriteRenderer.sprite = monster.sprite;
        currentHealthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxHealthTransform.rect.width * (float)health / maxHealth);
        animator.runtimeAnimatorController = monster.animatorController ? monster.animatorController : defaultAnimatorController;
        animator.SetTrigger("Spawned");
    }

    private void takeDamage(int damage)
    {
        if (health <= 0)
            return;
        damage -= defense;
        damage = Mathf.Max(0, damage);
        if(damage == 0)
        {
            return;
        }
        health -= damage;
        currentHealthTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxHealthTransform.rect.width * (float) health / maxHealth);
        if(health <= 0)
        {
            animator.SetTrigger("Dead");
            Events.enemyDied?.Invoke(monster);
            return;
        }
        animator.SetTrigger("Damaged");
        Events.enemyAttack?.Invoke(attack);
    }
}
