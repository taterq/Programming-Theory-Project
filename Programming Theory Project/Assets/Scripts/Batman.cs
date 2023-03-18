using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batman : PlayerUnit
{
    [SerializeField] private GameObject dartPrefab;
    [SerializeField] private bool inCoolDown = false;
    [SerializeField] private int dartNum = 20;
    [SerializeField] private float dartRange = 360;
    public override void OnAttacking()
    {
        if (!inCoolDown)
        {
            BatmanDart.Shoot(transform.position,mousePoint-transform.position,dartNum,dartRange);
            StartCoroutine(CoolDown());
        }
        base.OnAttacking();
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.3f);
        inCoolDown = false;
    }

    public override void InitInStart()
    {
        BatmanDart.dartPrefab = dartPrefab;
        base.InitInStart();
    }
}
