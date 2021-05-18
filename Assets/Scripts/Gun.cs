using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D Rocket;
    public float fSpeed = 10;
    PlayerControl playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown ("Fire1"))
        {
            Vector3 direction = new Vector3(0, 0, 0);
            if(playerCtrl .bFaceRight)
            {
                Rigidbody2D RocketInstance = Instantiate(Rocket, transform.position, Quaternion.Euler(direction )) ;
                RocketInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                direction.z = 180;
                Rigidbody2D RocketInstance = Instantiate(Rocket, transform.position, Quaternion.Euler(direction ));
                RocketInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }
    }
}
