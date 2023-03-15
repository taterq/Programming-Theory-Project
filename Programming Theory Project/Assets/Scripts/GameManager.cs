using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public Vector3 GetWorldPositionByMouse()
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = mainCamera.transform.position.y;
        return mainCamera.ScreenToWorldPoint(screenPos);
    }

}
