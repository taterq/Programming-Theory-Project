using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WeaponLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private RaycastHit hit = new RaycastHit();
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 direct;
    [SerializeField] private EntityState targetState;
    // Start is called before the first frame update
    void Start()
    {
        gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
        player = transform.parent;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direct = gameManager.mousePoint - player.position;
        if (Physics.Raycast(player.position, direct.normalized, out hit))
        {
            line.SetPosition(0, player.position);
            line.SetPosition(1, hit.point);
            targetState = hit.collider.GetComponent<EntityState>();
            if (targetState)
            {
                targetState.BeHit(1);
            }
        }
        else
        {
            line.SetPosition(0, player.position);
            line.SetPosition(1, gameManager.mousePoint);
        }
    }
}
