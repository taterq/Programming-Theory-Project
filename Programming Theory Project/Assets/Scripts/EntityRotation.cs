using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float speed;
    [SerializeField] public Vector3 direct=Vector3.forward;
    [SerializeField] private float maxDistance;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direct * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        maxDistance -= speed * Time.deltaTime;
        if (maxDistance < 0)
            Destroy(gameObject);
    }
}
