using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 screenPos;
    private void Start()
    {
        GameObject player = GameObject.Find("MainManager").GetComponent<MainManager>().GetPlayerInstance();
        player.transform.position = new Vector3(0, 0, 0);
    }
    public Vector3 mousePoint
    {
        get { return _mousePoint; }
    }
    [SerializeField] private Vector3 _mousePoint;

    private void Update()
    {
        _mousePoint = GetWorldPositionByMouse();
    }

    public Vector3 GetWorldPositionByMouse()
    {
        screenPos = Input.mousePosition;
        screenPos.z = mainCamera.transform.position.y;
        return mainCamera.ScreenToWorldPoint(screenPos);
    }

}
