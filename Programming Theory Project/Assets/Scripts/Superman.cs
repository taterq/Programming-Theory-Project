using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : PlayerUnit//INHERITANCE
{
    [SerializeField] private GameObject laser;
    public override void OnAttacking()//POLYMORPHISM
    {
        StopCoroutine("Lasering");
        StartCoroutine(Lasering());
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
