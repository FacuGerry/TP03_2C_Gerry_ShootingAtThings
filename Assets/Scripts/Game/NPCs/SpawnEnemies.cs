using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Enemy spawners")]
    [SerializeField] private BoxCollider[] _spawnPlaces = new BoxCollider[0];

    private MyPoolManager _mng;

    private void Start()
    {
        _mng = GameBootstrapper.Instance.PoolManager;

        int size = _mng.GetPoolSize<EnemyShoot>();

        for (int j = 0; j < size; j++)
        {
            EnemyShoot enemy = _mng.GetInstanceFromPool<EnemyShoot>(); // take new enemy

            BoxCollider coll = null;
            for (int i = 0; i < _spawnPlaces.Length; i++) // set which collider it will use to spawn
            {
                float rand = Random.value;
                if (rand <= (i / 10f))
                {
                    coll = _spawnPlaces[i];
                    break;
                }
            }
            if (coll == null)
                coll = _spawnPlaces[0];

            Bounds bounds = coll.bounds; // select position in collider to spawn
            Vector3 randomOffset = new(Random.Range(-bounds.extents.x, bounds.extents.x), bounds.extents.y, Random.Range(-bounds.extents.z, bounds.extents.z));
            Vector3 pos = bounds.center + randomOffset;

            enemy.Activate();
            enemy.transform.SetPositionAndRotation(pos, coll.gameObject.transform.rotation);
        }
    }
}