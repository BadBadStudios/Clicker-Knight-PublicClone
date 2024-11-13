using UnityEngine;
using UnityEngine.Events;
public static class Events
{
    public static UnityAction<int> playerAttack;
    public static UnityAction<int> enemyAttack;
    public static UnityAction<Monster> enemyDied;
}
