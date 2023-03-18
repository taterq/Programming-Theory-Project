using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider),typeof(EntityState),typeof(Rigidbody))]
public class PlayerUnit : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] static protected Vector3 mousePoint;
    [SerializeField] static protected GameManager gameManager;
    public EntityState state;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected string _playerName;
    [SerializeField] protected bool onAttacking = false;
    string playerName 
    {
        get { return _playerName;}
    }
    [SerializeField] protected Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        InitInStart();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGlobal();
        PlayerControl();
    }
    void PlayerControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right*h*Time.deltaTime*maxSpeed,Space.World);
        transform.Translate(Vector3.forward * v * Time.deltaTime*maxSpeed, Space.World);
        if (!onAttacking && Input.GetMouseButtonDown(0))
        {
            onAttacking = true;
            OnAttacking();
        }
        else if (onAttacking && Input.GetMouseButtonUp(0))
        {
            onAttacking = false;
        }
    }
    public virtual void OnAttacking()
    {

    }

    void UpdateGlobal()
    {
        mousePoint = gameManager.mousePoint;
    }

    public virtual void InitInStart()
    {
        GetComponent<Renderer>().material.color = color;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }
}
