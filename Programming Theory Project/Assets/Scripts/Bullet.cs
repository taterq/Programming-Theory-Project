using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int hit = 1;
    [SerializeField] private EntityState state;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            state = other.GetComponent<EntityState>();
            if (state)
                state.BeHit(hit);
            Destroy(gameObject);
        }
    }

}
