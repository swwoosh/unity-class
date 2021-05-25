using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backGrounds;
    public float fparallax = 2f;
    public float layerFraction = 10f;
    public float fSmooth = 8f;

    Transform cam;
    Vector3 previousCamPos;
    void Start()
    {
        previousCamPos = cam.position;
    }
    
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fparallax;
        for(int i = 0; i < backGrounds.Length; i++)
        {
            float fNewX = backGrounds[i].position.x + fParrlaxX * (1 + i * layerFraction);
            Vector3 newPos = new Vector3(fNewX, backGrounds[i].position.y, backGrounds[i].position.z);
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, newPos, fSmooth * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }
}
