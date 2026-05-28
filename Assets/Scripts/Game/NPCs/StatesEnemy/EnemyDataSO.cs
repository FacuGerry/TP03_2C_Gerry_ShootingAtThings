using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "NPCs/EnemyData")]

public class EnemyDataSO : ScriptableObject
{
    public EnemyClasses enemyClass;
    public float distanceToShoot;
}