using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rotationZ = Random.Range(0, 360);
        if (collision.tag != "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, rotationZ)));
            Destroy(gameObject);
        }
        if(collision .tag =="Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hurt();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
