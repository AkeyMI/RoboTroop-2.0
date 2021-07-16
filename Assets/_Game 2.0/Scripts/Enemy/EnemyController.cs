using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] GameObject spawnPointBullet = default;
    [SerializeField] EnemyStats enemyStats = default;

    //private EnemyStats currentStats;

    public Rigidbody Rb => rb;
    public EnemyStats Stats => enemyStats;

    //public Vector3 PositionSpawn => positionSpawn;

    private EnemyBaseState currentState;
    //private EnemyBaseState currentAttackState;
    private Rigidbody rb;
    private Vector3 positionSpawn;
    private int life;
    //private float timeToChangeType = 6f;

    //public readonly EnemyPatrolState PatrolState = new EnemyPatrolState();
    public readonly EnemyHuntState HuntState = new EnemyHuntState();
    public readonly EnemyDistanceAttackState AttackDistanceState = new EnemyDistanceAttackState();
    //public readonly EnemyMeleeAttackState AttackMeleeState = new EnemyMeleeAttackState();

    private void Start()
    {
        //currentStats = enemyFusionStats.enemyFusionStats[0];
        life = enemyStats.life;
        rb = GetComponent<Rigidbody>();
        //ChangeSpawnPoint(this.gameObject.transform.position);
        TransitionToState(HuntState);
    }

    private void Update()
    {
        currentState.Update(this);
        //CountDownToChangeType();
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    //public void ChangeSpawnPoint(Vector3 vec)
    //{
    //    positionSpawn = new Vector3(vec.x, vec.y, vec.z);
    //}

    public NaveController LocatePLayer()
    {
        NaveController nave = FindObjectOfType<NaveController>();

        return nave;
    }

    public void CreateBullet()
    {
        GameObject bullet = Instantiate(enemyStats.bullet, spawnPointBullet.transform.position, spawnPointBullet.transform.rotation);
        bullet.GetComponent<BulletEnemy>().Init(enemyStats.damage);
    }

    public void Damage(int amount)
    {
        life -= amount;

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
