using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : PlayerUnit
{
    [SerializeField] private GameObject laser;
    public override void OnAttacking()
    {
        StopCoroutine("Lasering");
        StartCoroutine(Lasering());
        base.OnAttacking();
    }

    IEnumerator Lasering()
    {
        laser.SetActive(true);
        while (onAttacking)
        {
            yield return new WaitForFixedUpdate();
        }
        laser.SetActive(false);
    }

}
