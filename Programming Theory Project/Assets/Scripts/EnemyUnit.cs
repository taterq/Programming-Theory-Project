using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider),typeof(EntityState))]
public abstract class EnemyUnit : MonoBehaviour
{
    [SerializeField] protected float centerRange;
    [SerializeField] protected float maxRange;
    [SerializeField] protected EntityState enemyState;
    [SerializeField] protected ParticleSystem deadParticle;
    protected enum ENEMYSTATE
    {
        MOVING,
        ATTACKING,
        BUSYING
    } 
    [SerializeField]protected ENEMYSTATE state=ENEMYSTATE.MOVING;
    // Start is called before the first frame update
    void Start()
    {
        InitState();
    }

    // Update is called once per frame
    void Update()
    {
        OnOutOfRange();
        AI();
    }
    public void BeHit(int hit)
    {
        enemyState.BeHit(hit);
        if (enemyState.isAlive)
        {
            StartCoroutine(ToDestroy());
        }
    }
    
    public IEnumerator ToDestroy()
    {
        deadParticle.Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void AI()
    {
        switch (state)
        {
            case ENEMYSTATE.MOVING:
                OnMoving();
                break;
            case ENEMYSTATE.ATTACKING:
                OnAttacking();
                break;
            case ENEMYSTATE.BUSYING:
                OnBusying();
                break;
            default:
                break;
        }
    }
    private void OnOutOfRange()
    {
        if (transform.position.x > maxRange || transform.position.x < -maxRange
            || transform.position.z > maxRange || transform.position.z < -maxRange)
        {
            Destroy(gameObject);
        }
    }


    abstract public void InitState();
    abstract public void OnMoving();
    abstract public void OnAttacking();
    abstract public void OnBusying();
}
