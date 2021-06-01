using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Sprite damageEnemy;
    public Sprite deadEnemy;
    public int HP = 2;
    public float maxSpinForce = 200;
    public float minSpinForce = -200;

    private Rigidbody2D enemyBody;
    private Transform frontCheck;
    private bool isDead = false;
    private SpriteRenderer curBody;
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontcheck");
        curBody = transform.Find("body").GetComponent<SpriteRenderer >();
    }
    private void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed, enemyBody.velocity.y);

        Collider2D[] colliders = Physics2D.OverlapPointAll(frontCheck .position );

        foreach (Collider2D c in colliders )
        {
            if(c.tag == "wall"||c.tag == "Enemy")
            {
                flip();
                break;
            }
        }

        if(HP == 1 && damageEnemy !=null)
        {
            curBody.sprite = damageEnemy;
        }
        if (HP <= 0 && !isDead )
        {
            death();
            
        }
    }
    void flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
    public void Hurt()
    {
        HP--;
    }
    void death()
    {
        isDead = true;
        curBody.sprite  = deadEnemy;

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
        //enemyBody.AddForce(Random.Range(minSpinForce, maxSpinForce));

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
