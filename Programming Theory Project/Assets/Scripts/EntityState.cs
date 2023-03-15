using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private int HP;
    [SerializeField] private bool _isAlive = true;
    public bool isAlive
    {
        get { return _isAlive; }
    }

    public void BeHit(int value)
    {
        HP -= value;
        if (HP < 1)
            _isAlive = false;
    }
}
