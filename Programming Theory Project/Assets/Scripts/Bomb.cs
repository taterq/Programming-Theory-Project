using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    public Vector3 target;
    public float speed;
    public float lastTime;
    public string targetLayer;
    [SerializeField] private int targetLayerMask;
    [SerializeField] private Color bombColor;
    [SerializeField] private Color bombSignColor;
    [SerializeField] private float bombRange=1;
    [SerializeField] private float damage = 1;
    [SerializeField] private ParticleSystem bombParticle;
    [SerializeField] private GameObject bombSignPrefab;
    [SerializeField] private GameObject bombSignInstance = null;
    [SerializeField] private float livedTime = 0;
    [SerializeField] private bool isExploded=false;
    // Start is called before the first frame update
    void Start()
    {
        target.y = transform.position.y;
        Vector3 direct = target - transform.position;
        transform.LookAt(target);
        speed = Mathf.Min(direct.magnitude / lastTime,speed);
        targetLayerMask = LayerMask.GetMask(targetLayer);
        GetComponent<Renderer>().material.color = bombColor;
        bombSignInstance=Instantiate(bombSignPrefab);
        Vector3 pos = target;
        pos.y = 0;
        bombSignInstance.transform.position = direct.normalized*lastTime*speed+transform.position;
        bombSignInstance.GetComponent<Renderer>().material.color = bombSignColor;
        bombSignInstance.transform.localScale = new Vector3(bombRange*2,0.001f,bombRange*2);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CountDown();
    }
    private void Move()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    private void CountDown()
    {
        livedTime += Time.deltaTime;
        if (livedTime >= lastTime && !isExploded)
        {
            StartCoroutine(Explode());
        }
    }
    private IEnumerator Explode()
    {
        isExploded = true;
        speed = 0;
        Destroy(bombSignInstance);
        bombParticle.gameObject.SetActive(true);
        GetComponent<Renderer>().enabled=false;
        Damage();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    private void Damage()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, bombRange, targetLayerMask);
        Debug.Log(targets.Length);
        foreach (var item in targets)
        {
            Debug.Log(item.gameObject.name);
            if (item.gameObject.CompareTag("Player"))
                item.gameObject.GetComponent<EntityState>().BeHit((int)damage);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Explode());
        }
    }
}
