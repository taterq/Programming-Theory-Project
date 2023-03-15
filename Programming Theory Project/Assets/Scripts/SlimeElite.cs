using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeElite : Slime
{
    [SerializeField] private float attackDelay = 1.8f;
    [SerializeField] private float attackCD = 2;
    [SerializeField] private GameObject bulletPrefab;
    public override void InitState()
    {
        InvokeRepeating("OnAttacking", attackDelay, attackCD);
        base.InitState();
    }

    public override void OnAttacking()
    {
        GameObject bomb=Instantiate(bulletPrefab,transform.position,bulletPrefab.transform.rotation);
        GameObject player=GameObject.FindGameObjectWithTag("Player");
        bomb.GetComponent<Bomb>().target = player.transform.position+new Vector3(Random.Range(-3f,3f),0,Random.Range(-1.5f,1.5f));
        bomb.GetComponent<Bomb>().targetLayer = "Player";
        base.OnAttacking();
    }

}
