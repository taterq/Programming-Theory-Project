using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : PlayerUnit
{
    [SerializeField] private GameManager manager;
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override void OnAttacking()
    {
        Vector3 pos = manager.GetWorldPositionByMouse();
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.
        base.OnAttacking();
    }
}
