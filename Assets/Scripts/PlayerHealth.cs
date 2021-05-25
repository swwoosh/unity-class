using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float health = 100f;
    public float healthpoint =20f;
    SpriteRenderer healthbar;
    Vector3 healthbarScale;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer >();
        healthbarScale = healthbar.transform.localScale;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(health >0)
            {
                takeDamage();
            }
            else
            {

            }
        }

    }
    void takeDamage()
    {
        health -= healthpoint;
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthbar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthbar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
    } 
    void Update()
    {
        
    }
}
