using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider),typeof(EntityState),typeof(Rigidbody))]
public class PlayerUnit : MonoBehaviour
{
    public EntityState state;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected string _playerName;
    string playerName 
    {
        get { return _playerName;}
    }
    [SerializeField] protected Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    void PlayerControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right*h*Time.deltaTime*maxSpeed,Space.World);
        transform.Translate(Vector3.forward * v * Time.deltaTime*maxSpeed, Space.World);
        
    }
    public virtual void OnAttacking()
    {

    }
}
