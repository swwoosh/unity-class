using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody2D heroBody;
    private Rigidbody2D rigidBody;
    public float moveforce = 100;
    public float jumpforce = 300;
    private float fInput = 0.0f;
    public float maxSpeed = 5;
    public  bool bFaceRight = true;
    private bool bGrounded = false;
    private bool bJump = false;
    Transform mGroundCheck;




    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
    }


    // Update is called once per frame  !!!!!
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        if (fInput < 0 && bFaceRight)
            flip();

        else if (fInput > 0 && !bFaceRight)
            flip();

        bJump = Input.GetButtonDown("Jump");
        if (bJump)
        {
            rigidBody.AddForce(new Vector2(0f, jumpforce));
            bJump = false;
        }

        bGrounded = Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
 
    }





    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < maxSpeed)
            heroBody.AddForce(fInput * moveforce * Vector2.right);

        if (Mathf.Abs(heroBody.velocity.x) > maxSpeed)
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * maxSpeed, heroBody.velocity.y);


    }


    private void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
