using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Scriptable Objects/Monster")]
public class Monster : ScriptableObject
{
    public int health;
    public int attack;
    public int defense;
    public Sprite sprite;
    public AnimatorOverrideController animatorController;
}
