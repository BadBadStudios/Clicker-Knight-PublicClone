using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    Monster[] monsters = null;
    [SerializeField]
    Enemy enemy;
    public int monstersKilled = 0;

    private void OnEnable()
    {
        Events.enemyDied += SpawnNewMonster;
    }

    private void OnDisable()
    {
        Events.enemyDied -= SpawnNewMonster;
    }

    private void SpawnNewMonster(Monster oldMonster)
    {
        SpawnMonster(monsters[Random.Range(0, monsters.Length)]);
    }

    private void Start()
    {
        SpawnMonster(monsters[Random.Range(0, monsters.Length)]);
    }

    public void SpawnMonster(Monster monster)
    {
        enemy.Initialize(monster);
    }
}
