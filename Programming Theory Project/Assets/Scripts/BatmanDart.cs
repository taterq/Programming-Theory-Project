using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BatmanDart
{
    [SerializeField] public static GameObject dartPrefab;

    public static void Shoot(Vector3 from,Vector3 direct, int dartsNum, float dartsRadius)
    {
        float[] angles = new float[dartsNum];
        float angle = Vector3.Angle(Vector3.forward,direct);
        angle -= dartsRadius / 2;
        float delta = dartsRadius / (dartsNum - 1);
        GameObject dart;
        for (int i = 0; i < dartsNum; i++)
        {
            dart=GameObject.Instantiate(dartPrefab,from,dartPrefab.transform.rotation);
            dart.transform.Rotate(Vector3.up,angle);
            dart.GetComponent<EntityRotation>().direct = dart.transform.forward;
            angle += delta;
        }
    }
}
