using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyUnit
{
    protected Rigidbody rg;
    [SerializeField] protected Color color = Color.red;
    [SerializeField] protected float delayTime = 2f;
    [SerializeField] protected float impact = 2f;
    [SerializeField] protected Vector3 direct;
    public override void InitState()
    {
        GetComponent<Renderer>().material.color = color;
        rg = GetComponent<Rigidbody>();
        transform.position = new Vector3(Random.Range(-centerRange, centerRange), 0.4f, Random.Range(-centerRange, centerRange));
        transform.Rotate(transform.up,Random.Range(-180f,180f));
        direct = transform.forward;
        transform.Translate(-direct * maxRange*0.7f);
    }

    public override void OnAttacking()
    {
        
    }

    public override void OnBusying()
    {
        
    }

    public override void OnMoving()
    {
        StartCoroutine(Jump(delayTime,impact));
    }

    IEnumerator Jump(float delay, float impact)
    {
        rg.AddForce(direct * impact, ForceMode.VelocityChange);
        state = ENEMYSTATE.BUSYING;
        yield return new WaitForSeconds(delay);
        state = ENEMYSTATE.MOVING;
    }
}
