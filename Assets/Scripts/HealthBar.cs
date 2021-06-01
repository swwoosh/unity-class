using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform playerTranform;
    public Vector3 offset = new Vector3(0, 1.3f, 0);
    // Start is called before the first frame update
    public void Awake()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform ;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTranform.transform.position + offset;
    }
}
